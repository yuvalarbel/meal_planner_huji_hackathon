#!%PYTHON_HOME%\python.exe
# coding: utf-8

import pandas as pd
import json
import sqlite3

# print current directory with absolute path
import os
print(os.path.abspath(os.curdir))
# flush the buffer
import sys
sys.stdout.flush()

conn = sqlite3.connect('../data.db')

# data = pd.read_csv("../../../recipes.csv")
# data.rename({'Unnamed: 0': 'id'}, axis=1, inplace=True)

raw_ingredients = pd.read_excel("raw_ingredients.xlsx")
# raw_ingredients.to_sql('ingredients', conn, if_exists='append', index=False)
ing_ids = dict(zip(raw_ingredients.name, raw_ingredients.index))

with open('recipes_df.pickle', 'rb') as f:
    recipes = pd.read_pickle(f)

recipes['ingredients_text'] = recipes.ingredients.str.slice(2, -2).str.replace('", "', '\n')
recipes['directions_text'] = recipes.directions.str.slice(2, -2).str.replace('", "', '\n')

recipes_table_data = recipes[['id', 'title', 'link', 'ingredients_text', 'directions_text']]
# recipes_table_data.to_sql('recipes', con=conn, if_exists='append', index=False)

ingredients_table_data = recipes[['id', 'NER']]

for _, (i, raw_ingredients) in ingredients_table_data.iterrows():
    raw_ingredients = json.loads(raw_ingredients)
    for ing in raw_ingredients:
        if ing in ing_ids:
            # print(f"yes: {i} {ing}")
            conn.execute(f"INSERT INTO recipe_ingredients (recipe_id, ingredient_id) "
                         f"VALUES ({i}, {ing_ids[ing]})")
        # else:
        #     print(f"no: {i} {ing}")

conn.commit()
conn.close()

# for i, (_, title, ingredients, directions, link, _, raw_ingredients) in data.iterrows():
#     ingredients = json.loads(ingredients)
#     directions = json.loads(directions)
#     raw_ingredients = json.loads(raw_ingredients)

