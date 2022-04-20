# PrePair - Our HUJI Hackathon 2022 Development
On 2022, the latest trend in Israel was "the Wolt challenge", where people contacted the customer service of Wolt to disciver the unvelivable amount of money they spent on ordering food during the past year. 
Most of these people who were shocked to find how much they spend on food takeout and deliveries, *_want_ to cook more, but _feel like it's too much effort_*. You'd have to look for a recipe that matches your preferances out of billions of recipes online, than see if you even have the ingredients for it, and go to the grocery store to buy what you don't have... just the thought of all the work you have to do *before* you start cooking, makes a lot of people give up on the idea.
We came to solve that exact problem, and we are exited to introduce our MVP for *PrePair*, the app that *Peels away wasted time until you start cooking!*
![image](https://user-images.githubusercontent.com/36603609/164168475-62e9c4d8-6ece-4cc4-b91d-fc6fc19149bd.png)

## The Solution
The PrePair app consists of 3 stages - 
* Tell us (using a quick, intuitive UI) what you have in your pantry. 
* Choose from the recipes that matched your ingredients (chosen for you from over 2 million recipes). We will choose recipes that does'nt require you to buy anything, or ones that has a few ingredients you don't have, that cost up to 30 NIS. 
* If you chose a recipe that requires missing ingredients, we will contact a local grocery supplier and arrange a quick delivery to your door. 
With PrePair, arranging to cook something delicious, healthy and cheep only takes less 2 minutes!
![image](https://user-images.githubusercontent.com/36603609/164168559-aaeec5e3-ef9d-4811-88ee-566d6cd4c47e.png)

## User Experience & Data Driven
We knew that our solution has to be quick and easy to use in order for users to choose it. Many existing solutions to this problem did not appeal to users since they required choosing from an extremely long lost of ingredients. 
The main UI features that makes PrePair fun and easy to use:
* Choosing ingredient is done using swiping (right for "I have it" and left for "I don't"), which is much more fun and quick than choosing from a list.
* You choose when to stop - with every ingredient you add, the amount of recipes that will be chosen for you will increase, and you can choose when to stop adding ingreadients when you feel you have enaugh options. 
* Ingredients are shown in a logical order - instead of showing them by category (as commonly done in such apps), PrePair shows you the most common items first, to make sure you get as many recipes as quick as possible. 
* We will never leave you hungry - even if you give us an absurd list of ingredients that doesn't match any of our recipes, we will still be there for you - we have an AI system that will generate on the spot a new recipe for you based on the ingredients you do have. 
![image](https://user-images.githubusercontent.com/36603609/164170245-b15349ef-ce62-4bef-80e2-a46f389f8679.png)


## Techonological Stack
This web app was developed in 24 hours during the HUJI Hackathon 2022, and won 4th place in the competition (out of 48 groups).
It is designed to be a mobile app, but our MVP is a windows application, with a fully functional frontend user interface built using Visual C#, along with a funcational backend that has a Flask server and a SQLite database. 
We are using the incredible Chef Transformer to generate our AI recipes - https://huggingface.co/spaces/flax-community/chef-transformer

## Our Team 
![image](https://user-images.githubusercontent.com/36603609/164171115-dfc4510e-7d32-4fab-b879-7ec409c81f93.png)

Credits for images and icons used in this project:
<a href="https://www.flaticon.com/free-icons/return" title="return icons">Return icons created by Uniconlabs - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/return" title="return icons">Return icons created by alkhalifi design - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/settings" title="settings icons">Settings icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/bacon" title="bacon icons">Bacon icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/fried-egg" title="fried egg icons">Fried egg icons created by Icon home - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/egg" title="egg icons">Egg icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/butter" title="Butter icons">Butter icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/carrot" title="carrot icons">Carrot icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/food" title="food icons">Food icons created by Smashicons - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/onion" title="onion icons">Onion icons created by Good Ware - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/potato" title="potato icons">Potato icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/sugar" title="sugar icons">Sugar icons created by juicy_fish - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/chicken" title="chicken icons">Chicken icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/milk" title="milk icons">Milk icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/rice" title="rice icons">Rice icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/tomato" title="tomato icons">Tomato icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/bread" title="bread icons">Bread icons created by kerismaker - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/celery" title="celery icons">Celery icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/garlic" title="garlic icons">Garlic icons created by Smashicons - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/salad" title="salad icons">Salad icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/bacon" title="bacon icons">Bacon icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/cooking" title="cooking icons">Cooking icons created by mangsaabguru - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/dairy-free" title="dairy free icons">Dairy free icons created by surang - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/gluten-free" title="gluten free icons">Gluten free icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/food-and-restaurant" title="food and restaurant icons">Food and restaurant icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/vegan" title="vegan icons">Vegan icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/vegan" title="vegan icons">Vegan icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/no-meat" title="no meat icons">No meat icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/soy-free" title="soy free icons">Soy free icons created by PLANBSTUDIO - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/kosher" title="kosher icons">Kosher icons created by Freepik - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/shekel" title="shekel icons">Shekel icons created by Royyan Wijaya - Flaticon</a>
<a href="https://www.flaticon.com/free-icons/clock" title="clock icons">Clock icons created by dmitri13 - Flaticon</a>
