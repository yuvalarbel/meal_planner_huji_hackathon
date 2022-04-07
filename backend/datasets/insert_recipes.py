#!%PYTHON_HOME%\python.exe
# coding: utf-8

import pandas as pd
import json
import sqlite3

conn = sqlite3.connect('../data')

data = pd.read_csv("../../../recipes.csv")
data.rename({'Unnamed: 0': 'id'}, axis=1, inplace=True)

with open('rec_ids.json', 'r') as f:
    recipe_ids = json.load(f)

with open('ings.json', 'r') as f:
    raw_ingredients = json.load(f)




recipes_data = data[['id', 'title', 'link']][data['id'].isin(recipe_ids)]
recipes_data.to_sql('recipes', con=conn, if_exists='append', index=False, chunksize=1000)

# all_raw_ingredients = set()
# for _, (i, title, ingredients, directions, link, _, raw_ingredients) in data.iterrows():
#     raw_ingredients = json.loads(raw_ingredients)
#     all_raw_ingredients.update(raw_ingredients)

# for i, (_, title, ingredients, directions, link, _, raw_ingredients) in data.iterrows():
#     ingredients = json.loads(ingredients)
#     directions = json.loads(directions)
#     raw_ingredients = json.loads(raw_ingredients)

