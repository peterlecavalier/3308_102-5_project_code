var express = require('express');
var app = express();
var bodyParser = require('body-parser');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

var pgp = require('pg-promise')();

const dbConfig = process.env.DATABASE_URL;
const crypto = require('crypto');

var db = pgp(dbConfig);

app.set('view engine', 'ejs');
app.use(express.static(__dirname + '/'));

app.get('/about', function(req, res) {
	res.render('pages/about',{
		my_title:"About us"
	});
});

app.get('/', function(req, res) {
	var list_players = 'select * from leader_players ORDER BY total_coins DESC;';

  db.task('get-everything', task => {
        return task.batch([
            task.any(list_players)
        ]);
    })
    .then(data => {
    	res.render('pages/index',{
				my_title: "Short Fuze Scoreboard",
				players: data[0]
			})
    })
    .catch(error => {
        // display error message in case an error
            request.flash('error', err);
            response.render('pages/index', {
                title: 'Short Fuze Scoreboard',
                players: '',
            })
    });
});

app.get('/insert_player', async function(req, res) {

	var username = req.query.username;
	var coins = req.query.coins;
	var hash = req.query.hash;
	var secretKey = '1029384756qpwoeiruty';
	var realHash = crypto.createHash('md5').update(username + coins + secretKey).digest("hex");
	var insert_statement;
	if(hash == realHash){
		coins = parseInt(coins);
		var search_statement = "SELECT * FROM leader_players WHERE username='" + username + "';";
		var id_result = await db.query(search_statement, (err, res) => {
				console.log(err, res);
  	});
		if(id_result.length > 0){
			var games_played = parseInt(id_result[0].games_played) + 1;
			var most_coins = parseInt(id_result[0].most_coins);
			if(coins > parseInt(id_result[0].most_coins)){
				most_coins = coins;
			}
			var total_coins = parseInt(id_result[0].total_coins) + coins;
			insert_statement = "UPDATE leader_players SET games_played=" + games_played + ", most_coins=" + most_coins + ", total_coins=" + total_coins +
					"WHERE id=" + id_result[0].id;
		}
		else{
			insert_statement = "INSERT INTO leader_players(username, games_played, most_coins, total_coins) VALUES('" + username + "',1," +
									 coins + "," + coins + ");";
		}
		await db.query(insert_statement, (err, res) => {
				if(err){
					console.log(err, res);
					db.exit();
				}
		});
	}
});

app.listen(process.env.PORT);
