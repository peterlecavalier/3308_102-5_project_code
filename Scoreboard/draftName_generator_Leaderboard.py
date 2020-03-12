#!/usr/bin/env python
# coding: utf-8

# Matthew White
# Steve Jobs Rejected Interns
# CSCI 3308

# generic imports copied from AI notebook
##from scipy import stats
##from math import floor, isclose
##from time import time
##import numpy as np
##import pandas as pd
##import matplotlib.pyplot as plt
# imports for this notebook
import random
import string


def name_generator(number_of_players):
#     Generates and returns a list of random player names and their scores
#     Will be used for showing Leaderboard proof of concept
#     parameter number_of_players - number of players desired in list

    player_list = []
    lower_alphabet = string.ascii_lowercase
    
#     Generate a random player name
#     - Will have 1 to 5 letters and 1 to 5 numbers as player name
    
    for names in range(number_of_players):
        name = []
        letter_count = random.randrange(1, 5)
        number_count = random.randrange(1, 5)
        for letter in range(letter_count):
            random_letter = random.choice(lower_alphabet)
            name.append(random_letter)
        for number in range(number_count):
            random_number = random.randrange(10)
            name.append(str(random_number))
            
#         combine the list of letters and numbers into the player name
        string_name = ''.join(name)
        
#         Generate a random score up to 1000000
        player_score = random.randrange(1000000)
        
#         Make the dictionary and add it to the list
        player_details = {string_name:player_score}
        player_list.append(player_details)
        
    return player_list

# test of name_generator function
playdudes = name_generator(4)
print(playdudes)

# main() description
# Uses name_generator function to make a list of 200 players and their scores
# Writes that list to a csv file called "player_scores.csv"
# Checks the file by printing the first 10 lines of the csv file

def main():
#     generate list of player/score dictionaries
    playas = name_generator(200)
    
#     open file for writing
    f = open("player_scores.csv","w+")
    
#     Write column headers
    f.write("Player, Score\r")

#     iterate through the list of dictionaries and write each one to a row in the file
    for dic in playas:
        for key in dic:
            comma = ','
            row = (key + comma + str(dic[key]))
            f.write(row)
            f.write('\r')
    
#     close the file
    f.close()
    
#     test - open the file, print first 10 lines, close the file
    fread = open("player_scores.csv", "r")
    for line in range(10):
        print(fread.readline())
    fread.close()
# end of main()

if __name__== "__main__":
  main()

