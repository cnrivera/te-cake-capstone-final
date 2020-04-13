-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('name', 'KgrolkOWjHuNvQtFrGwZOqGm5qs=', 'V7CHRJ6vltc=', 'User');

-- STANDARD CAKE INSERT STATEMENTS -- 

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Holy Sheet Cake!', 45, 'Sheet cake', 'Full-pan', 'Yellow', 'Hazelnut Buttercream', 'None', 'A great basic cake for any event. Delicious hazelnut buttercream icing pairs perfectly with yellow sponge cake.', 'sheet-cake-yellow-chocolate-frosting.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Garden Party Sheet Cake', 50, 'Sheet cake', 'Half-pan', 'Lemon Poppyseed', 'Vanilla Buttercream', 'None', 'A beautiful cake for any occassion. Sweet lemon poppyseed sponge cake topped with vanilla buttercream and decorated with lovely buttercream roses.', 'sheet-cake-vanilla-roses.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Elegant Wedding Cake', 300, 'Layer Cake', '3-tier', 'Chocolate', 'Fondant', 'None', 'A picture-perfect wedding cake to enhance your special day and impress your guests. Three tiers of chocolate covered in white fondant and decorated with edible icing pearls.', 'layer-cake-three-tier-wedding.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Keep You Awake Espresso Cake', 50, 'Layer Cake', '8-inch', 'Espresso', 'Chocolate Ganache', 'Cream', 'Take a sensory journey with this luscious speciality cake that will keep you up thinking about it all night long. Espresso-flavored cake layered with mocha and vanilla cream, topped with a layer of chocolate ganache, and patted with chocolate coffee crumbles.', 'layer-cake-chocolate-espresso.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Devilishly Decadent Cupcake', 3, 'Cupcake', 'Standard', 'Chocolate', 'Chocolate Buttercream', 'Raspberry', 'Satisfy your sweet tooth with this delectably devilish cupcake. Chocolate cake with raspberry filling topped with white and milk chocolate buttercream icing and a fresh raspberry.', 'cupcake-chocolate-cream.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Good Enough to Drink Cupcake', 3, 'Cupcake', 'Standard', 'Chai', 'Nutmeg Buttercream', 'None', 'Drink your chai and eat it, too, with this deliciously spiced cupcake. Chai cake with nutmeg icing sprinkled with cinnamon and sugar.', 'cupcake-chai-latte.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Celebrate Cookie Cake', 40, 'Cookie Cake', '12-inch', 'Chocolate chip', 'Chocolate', 'None', 'Make any day a celebration with this delicious cookie cake. Chocolate chip cookie outlined with chocolate icing and sprinkled with edible multi-colored confetti.', 'cookie-cake-confetti.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Peanut Butter Bonanza Cookie Cake', 70, 'Cookie Cake', '18-inch', 'Peanut Butter', 'Chocolate', 'Reeses Pieces', 'Have a blast with this fantastically flavored cookie cake. Peanut butter cookie mixed with Reeses Pieces, outlined with chocolate icing, and sprinkled with edible multi-colored confetti.', 'cookie-cake-peanut-butter.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Magical Dimension Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Chocolate', 'Whipped Cream', 'Strawberry', 'Enjoy a bit of magic with this beautifully layered ice cream cake. Chocolate ice cream with a center layer of strawberry ice cream covered in whipped cream frosting and topped with a layer of chocolate hard shell and multi-colored sprinkles.', 'ice-cream-cake-layered-hard-shell.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Oh Ho, Oreo! Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Cookies and Cream', 'Whipped Cream', 'Cookie', 'This family-favorite ice cream cake will make your day all the sweeter. Cookies-and-cream ice cream with a chocolate cake base layer, topped with whipped cream frosting, drizzled with chocolate hard shell, outlined with a circle of chocolate icing shells, and wedged with whole Oreo cookies.', 'ice-cream-cake-oreo.png');

-- CUSTOM CAKE INSERT STATEMENTS --

INSERT INTO styles (available, style, price)
VALUES ( 1, 'Sheet cake', 1)

INSERT INTO fillings (available, filling, additional_cost)
VALUES ( 1, 'None', 1)

INSERT INTO flavors (available, flavor)
VALUES ( 1, 'Yellow')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Hazelnut Buttercream')

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Full-pan', 70)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Half-pan', 40)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '3-tier', 100)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Standard', 4)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '8-inch', 40)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '12-inch', 75)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '18-inch', 125)

INSERT INTO style_size (style_id, size_id)
VALUES (1, 1), (1,2)

--INSERT INTO custom_cakes (name, price, style_id, size_id, flavor_id, frosting_id, filling_id, description, image_path)
--VALUES ('Holy Sheet Cake!', 45,  , 1 , 1, 1, 1, 'A great basic cake for any event. Delicious hazelnut buttercream frosting pairs perfectly with yellow sponge cake.', 'sheet-cake-yellow-chocolate-frosting.png');

--select name, styles.style, sizes.size, flavors.flavor, frostings.frosting, fillings.filling, description, image_path from cakes 
--join styles on cakes.style_id = styles.id
--join sizes on cakes.size_id = sizes.id
--join flavors on cakes.flavor_id = flavors.id
--join frostings on cakes.frosting_id = frostings.id
--join fillings on cakes.filling_id = fillings.id


--ORDER INSERT STATEMENTS--

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Holy Sheet Cake!', 1, 'Sheet cake', 'Full-pan', 'Yellow', 'Hazelnut Buttercream', 'none', null, 50, 'pending', 'Xanth Hively', '867-5309', 'lilxanth@gmail.com', '2020-04-10 15:00:00.000');

SELECT * from standard_cakes

SELECT * from orders


COMMIT TRANSACTION;
