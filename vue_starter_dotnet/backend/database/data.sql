-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Holy Sheet Cake!', 45, 'Sheet cake', 'Full-pan', 'Yellow', 'Hazelnut Buttercream', 'None', 'A great basic cake for any event. Delicious hazelnut buttercream icing pairs perfectly with yellow sponge cake.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Garden Party Sheet Cake', 50, 'Sheet cake', 'Half-pan', 'Lemon Poppyseed', 'Vanilla Buttercream', 'None', 'A beautiful cake for any occassion. Sweet lemon poppyseed sponge cake topped with vanilla buttercream and decorated with lovely buttercream roses.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Elegant Wedding Cake', 300, 'Layer Cake', '3-tier', 'Chocolate', 'Fondant', 'None', 'A picture-perfect wedding cake to enhance your special day and impress your guests. Three tiers of chocolate covered in white fondant and decorated with edible icing pearls.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Keep You Awake Espresso Cake', 50, 'Layer Cake', '8-inch', 'Espresso', 'Chocolate Ganache', 'Cream', 'Take a sensory journey with this luscious speciality cake. Espresso-flavored cake layered with mocha and vanilla cream, topped with a layer of chocolate ganache, and patted with chocolate coffee crumbles.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Devilishly Decadent Cupcake', 3, 'Cupcake', 'Standard', 'Chocolate', 'Chocolate Buttercream', 'Raspberry', 'Satisfy your sweet tooth with this delectably devilish cupcake. Chocolate cake with raspberry filling topped with white and milk chocolate buttercream icing and a fresh raspberry.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Good Enough to Drink Cupcake', 3, 'Cupcake', 'Standard', 'Chai', 'Nutmeg Buttercream', 'None', 'Drink your chai and eat it, too, with this deliciously spiced cupcake. Chai cake with nutmeg icing sprinkled with cinnamon and sugar.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Celebrate Cookie Cake', 40, 'Cookie Cake', '12-inch', 'Chocolate chip', 'Chocolate', 'None', 'Make any day a celebration with this delicious cookie cake. Chocolate chip cookie outlined with chocolate icing and sprinkled with multi-colored confetti sprinkles.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Peanut Butter Bonanza Cookie Cake', 70, 'Cookie Cake', '18-inch', 'Peanut Butter', 'Chocolate', 'Reeses Pieces', 'Have a blast with this fantastically flavored cookie cake. Peanut butter cookie mixed with Reeses Pieces, outlined with chocolate icing, and sprinkled with multi-colored confetti sprinkles. ');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Magical Dimension Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Chocolate', 'Whipped Cream', 'Strawberry', 'Enjoy a bit of magic with this beautifully layered ice cream cake. Chocolate ice cream with a center layer of strawberry ice cream covered in whipped cream frosting and topped with a layer of chocolate hard shell and multi-colored sprinkles.');

INSERT INTO cakeinfo (name, price, style, size, flavor, icing, filling, description)
VALUES ('Oh Ho, Oreo! Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Cookies and Cream', 'Whipped Cream', 'Cookie', 'This family-favorite ice cream cake will make your day all the sweeter. Cookies-and-cream ice cream with an Oreo cookie layer, topped with whipped cream frosting and chooclate sprinkles, outlined with a circle of chocolate icing, and wedged with whole Oreo cookies.');



COMMIT TRANSACTION;
