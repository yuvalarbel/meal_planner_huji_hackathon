#!%PYTHON_HOME%\python.exe
# coding: utf-8

MAX_USER_QUERY = "SELECT MAX(id) FROM users"


FREE_RECIPES_QUERY = """
SELECT COUNT(*) AS num_free
  FROM recipes
 WHERE id IN (
     SELECT recipe_id
     FROM recipe_ingredients
     WHERE recipe_id NOT IN (
         SELECT recipe_id
         FROM recipe_ingredients
         WHERE ingredient_id NOT IN (
             SELECT id
             FROM ingredients
             WHERE name IN ('{ingredients}'))
     )
 )
{kosher}
;"""

PAID_RECIPES_QUERY = """
WITH recipe_prices AS
(SELECT ri.recipe_id, SUM(i.price) AS sum_price
  FROM recipe_ingredients ri
 INNER JOIN ingredients i ON (i.id = ri.ingredient_id)
 WHERE ri.recipe_id IN (
     SELECT DISTINCT recipe_id
     FROM recipe_ingredients
     WHERE recipe_id IN (
         SELECT recipe_id
         FROM recipe_ingredients
         WHERE ingredient_id NOT IN (
             SELECT id
             FROM ingredients
             WHERE name IN ('{ingredients}'))
     )
 )
  AND ri.ingredient_id NOT IN (
     SELECT id
     FROM ingredients
     WHERE name IN ('{ingredients}')
 )
{constraints}
 GROUP BY recipe_id
 HAVING sum_price < {price})
 
SELECT rp.recipe_id, rp.sum_price
  FROM recipe_prices rp
 INNER JOIN recipes r ON (r.id = rp.recipe_id)
{kosher}
 ORDER BY sum_price ASC;"""
