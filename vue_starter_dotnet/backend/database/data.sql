-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('user', 'jUE98uhvS5tdIlxRsmz1W7/Qaqo=', '9CWPUTvXqQ4=', 'User');
INSERT INTO cakeinfo (name,price,style,size,flavor,icing,filling,description)
VALUES ('holy sheet cake','50','sheet cake','large','vanilla','chocolate','raspberry','thats a damn good cake');
INSERT INTO cakeinfo (name,price,style,size,flavor,icing,filling,description)
VALUES ('nice cake','40','layer cake','small','vanilla','chocolate','vanilla','MMMmmmm cake!');


COMMIT TRANSACTION;
