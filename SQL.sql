/* Since I didn't have the chance or need to use SQL before at work, I decided to freshen up on my SQL skills that I had learned in school.
I have finished the Codecademy's SQL course in 2017, then reviewed the course again at the beginning of 2018.
This time, I decided to review SQL using different online courses - I did the sqlcourse.com which is intended for beginners and then I also did the sqlcourse2.com. 
I explored the w3schools SQL tutorials at https://www.w3schools.com/sql/default.asp, as well.
I wanted to share here some queries that retrieve data from the tables "items_ordered" http://www.sqlcourse2.com/items_ordered.html and "customers" http://www.sqlcourse2.com/customers.html 
that I had done for practice while doing the sqlcourse2.com course. */

-- SELECT statement review exercises:
-- From the items_ordered table, select a list of all items purchased for customerid 10449. Display the customerid, item, and price for this customer.
SELECT customerid, item, price
FROM items_ordered
WHERE customerid = 10449
ORDER BY item ASC;

-- Select all columns from the items_ordered table for whoever purchased a Tent.
SELECT * 
FROM items_ordered
WHERE item = 'Tent';

-- Select the customerid, order_date, and item values from the items_ordered table for any items in the item column that start with the letter "S".
SELECT customerid, order_date, item
FROM items_ordered
WHERE item LIKE 'S%';

-- Select the distinct items in the items_ordered table. In other words, display a listing of each of the unique items from the items_ordered table.
SELECT DISTINCT item
FROM items_ordered;

-- Aggregate Functions review exercises:
-- Select the maximum price of any item (all items?) ordered in the items_ordered table. 
SELECT MAX(price) 
FROM items_ordered; --this would yield only the price of the most expensive ordered item 
-- it would be better to select the item, as well, and to use GROUP BY
SELECT item, MAX(price) 
FROM items_ordered
GROUP BY item; -- this way we get the highest price for, say, all the tents, all the flashlights, etc.

-- Select the average price of all of the items ordered that were purchased in the month of Dec.
SELECT AVG(price) 
FROM items_ordered
WHERE order_date LIKE '%Dec%';

-- What are the total number of rows in the items_ordered table?
SELECT COUNT(*)
FROM items_ordered;

-- For all of the tents that were ordered in the items_ordered table, what is the price of the lowest tent? 
SELECT MIN(price) 
FROM items_ordered 
WHERE item = 'Tent';

-- GROUP BY clause review exercises:
-- How many people are in each unique state in the customers table? Select the state and display the number of people in each. 
SELECT DISCTINCT state, COUNT(customerid)  
FROM customers  
GROUP BY state;

-- From the items_ordered table, select the item, maximum price, and minimum price for each specific item in the table. Hint: The items will need to be broken up into separate groups.
SELECT item, MAX(price), MIN(price)
FROM items_ordered  
GROUP BY item; 

-- How many orders did each customer make? Use the items_ordered table. Select the customerid, number of orders they made, and the sum of their orders. Click the Group By answers link below if you have any problems.
SELECT customerid, COUNT(customerid), SUM(price)
FROM items_ordered
GROUP BY customerid;

-- HAVING clause review exercises:
-- How many people are in each unique state in the customers table that have more than one person in the state? Select the state and display the number of how many people are in each if it's greater than 1.
SELECT state, COUNT(state)
FROM customers
GROUP BY state
HAVING COUNT(state) > 1;

-- From the items_ordered table, select the item, maximum price, and minimum price for each specific item in the table. Only display the results if the maximum price for one of the items is greater than 190.00.
SELECT item, MAX(price), MIN(price)
FROM items_ordered
GROUP BY item
HAVING MAX(price) > 190.00;

-- How many orders did each customer make? Use the items_ordered table. Select the customerid, number of orders they made, and the sum of their orders if they purchased more than 1 item.
SELECT customerid, COUNT(customerid), SUM(price)
FROM items_ordered
GROUP BY customerid
HAVING COUNT(customerid) > 1;

-- ORDER BY clause review exercises:
-- Select the lastname, firstname, and city for all customers in the customers table. Display the results in Ascending Order based on the lastname.
SELECT lastname, firstname, city 
FROM customers
ORDER BY lastname ASC;

-- Same thing as exercise #1, but display the results in Descending order.
SELECT lastname, firstname, city 
FROM customers
ORDER BY lastname DESC;

-- Select the item and price for all of the items in the items_ordered table that the price is greater than 10.00. Display the results in Ascending order based on the price.
SELECT item, price
FROM items_ordered
WHERE price > 10.00
ORDER BY price ASC;

-- Combining Conditions & Boolean Operators review exercises:
-- Select the customerid, order_date, and item from the items_ordered table for all items unless they are 'Snow Shoes' or if they are 'Ear Muffs'. Display the rows as long as they are not either of these two items.
SELECT customerid, order_date, item
FROM items_ordered
WHERE (item <> 'Snow Shoes') AND (item <> 'Ear Muffs');

-- Select the item and price of all items that start with the letters 'S', 'P', or 'F'.
SELECT item, price
FROM items_ordered
WHERE item LIKE 'S%' OR item LIKE 'P%' OR item LIKE 'F%'
ORDER BY item DESC;

-- IN & BETWEEN conditional operators review exercises:
-- Select the date, item, and price from the items_ordered table for all of the rows that have a price value ranging from 10.00 to 80.00.
SELECT order_date, item, price 
FROM items_ordered 
WHERE price BETWEEN 10.00 AND 80.00;

-- Select the firstname, city, and state from the customers table for all of the rows where the state value is either: Arizona, Washington, Oklahoma, Colorado, or Hawaii.
SELECT firstname, city, state 
FROM customers 
WHERE state IN ('Arizona', 'Washington', 'Oklahoma', 'Colorado', 'Hawaii')
ORDER BY state;

-- Mathematical Functions review exercises:
-- Select the item and per unit price for each item in the items_ordered table. 
SELECT item, ROUND(price/quantity, 2)
FROM items_ordered
ORDER BY item ASC;

-- Table Joins review exercises:
-- Write a query using a join to determine which items were ordered by each of the customers in the customers table. 
-- Select the customerid, firstname, lastname, order_date, item, and price for everything each customer purchased in the items_ordered table.
SELECT customers.customerid, customers.firstname, customers.lastname,
items_ordered.order_date, items_ordered.item, items_ordered.price
FROM customers JOIN items_ordered
ON customers.customerid = items_ordered.customerid;

-- Repeat exercise #1, however display the results sorted by state in descending order.
SELECT customers.customerid, customers.firstname, customers.lastname,
items_ordered.order_date, items_ordered.item, items_ordered.price
FROM customers JOIN items_ordered
ON customers.customerid = items_ordered.customerid
ORDER BY customers.state DESC;

-- query with LEFT JOIN - the idea is to combine customer and items_ordered tables, and retrieve ALL selected data from the customers table as well as the corresponding data from the orders table, even if a customer hasn’t ordered anything yet.

SELECT customers.customerid, customers.firstname, customers.lastname,
items_ordered.order_date, items_ordered.item, items_ordered.price
FROM customers LEFT JOIN items_ordered
ON customers.customerid = items_ordered.customerid
ORDER BY customers.customerid;

-- At https://sqlbolt.com/lesson/select_queries_with_joins - Find the domestic and international sales for each movie 
SELECT movies.id, movies.title, 
boxoffice.domestic_sales, boxoffice.international_sales
FROM movies 
INNER JOIN boxoffice
ON movies.id = boxoffice.movie_id
ORDER BY movies.id;
-- ok, so, having in mind the set theory, INNER JOIN is obviously the intersection of two tables

-- At https://sqlbolt.com/lesson/select_queries_with_joins - Show the sales numbers for each movie that did better internationally rather than domestically
SELECT movies.id, movies.title, 
boxoffice.domestic_sales, boxoffice.international_sales
FROM movies 
INNER JOIN boxoffice
ON movies.id = boxoffice.movie_id
WHERE boxoffice.international_sales > boxoffice.domestic_sales
ORDER BY movies.id;

-- At https://sqlbolt.com/lesson/select_queries_with_joins List all the movies by their ratings in descending order
SELECT movies.id, movies.title, 
boxoffice.rating
FROM movies 
INNER JOIN boxoffice
ON movies.id = boxoffice.movie_id
ORDER BY boxoffice.rating DESC;

-- At https://sqlbolt.com/lesson/select_queries_with_nulls Using the data from the buildings and employees tables, find the names of the buildings that hold no employees. Good example of LEFT (OUTER) JOIN, as well.
SELECT buildings.building_name 
FROM buildings 
LEFT JOIN employees
ON buildings.building_name = employees.building
WHERE employees.building IS NULL;

-- Practice of SELF JOIN at https://www.w3schools.com/sql/trysql.asp?filename=trysql_select_join_self, SELECTing customers whose order was taken by the same employee
SELECT DISTINCT A.CustomerID, A.EmployeeID
FROM Orders A, Orders B
WHERE A.CustomerID <> B.CustomerID
AND A.EmployeeID = B.EmployeeID
ORDER BY A.EmployeeID;

-- Still, this example may not be ideal for SELF JOIN, as the same data can be retrieved with:
SELECT CustomerID, EmployeeID 
FROM Orders
ORDER BY EmployeeID;












