var express = require('express');
var app = express();
var bodyParser = require('body-parser');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

var pgp = require('pg-promise')();

const dbConfig = process.env.DATABASE_URL;

var db = pgp(dbConfig);

app.set('view engine', 'ejs');
app.use(express.static(__dirname + '/'));

app.get('/index', function(req, res) {
	var list_players = 'select * from leader_players ORDER BY total_coins DESC;'; //REPLACE football_games WITH TABLE NAME

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

app.listen(process.env.PORT);
