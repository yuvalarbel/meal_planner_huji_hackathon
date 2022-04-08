CREATE TABLE users (
  id INTEGER PRIMARY KEY,
  username TEXT NOT NULL,
  password TEXT NOT NULL,
  email TEXT NOT NULL,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE user_settings (
  user_id INTEGER NOT NULL,
  kosher BOOLEAN,
  no_meat BOOLEAN,
  no_nuts BOOLEAN,
  no_dairy BOOLEAN,
  no_eggs BOOLEAN,
  no_soy BOOLEAN,
  no_gluten BOOLEAN,
  FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE recipes (
  id INTEGER PRIMARY KEY,
  title TEXT NOT NULL,
  link TEXT NOT NULL,
  ingredients_text TEXT NOT NULL,
  directions_text TEXT NOT NULL,
  image_path TEXT
);

CREATE TABLE ingredients (
  id INTEGER PRIMARY KEY,
  name TEXT NOT NULL,
  price REAL NOT NULL,
  contains_meat BOOLEAN,
  contains_nuts BOOLEAN,
  contains_dairy BOOLEAN,
  contains_eggs BOOLEAN,
  contains_soy BOOLEAN,
  contains_gluten BOOLEAN
);

CREATE TABLE recipe_ingredients (
  recipe_id INTEGER NOT NULL,
  ingredient_id INTEGER NOT NULL,
  FOREIGN KEY (recipe_id) REFERENCES recipes(id),
  FOREIGN KEY (ingredient_id) REFERENCES ingredients(id)
);