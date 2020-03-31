-- NOTE Manufacturers
-- CREATE TABLE manufacturers (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (ID)
-- );


-- NOTE SHOES | ONE TO MANY RELATIONSHIP

-- CREATE TABLE shoes (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     size INT NOT NULL,
--     price DECIMAL (6, 2),
--     mfgId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (mfgId)
--         REFERENCES manufacturers(id)
--         ON DELETE CASCADE
-- );


-- NOTE Cart

-- CREATE TABLE carts (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )


-- NOTE CartShoes

-- CREATE TABLE cartshoes (
--     id INT NOT NULL AUTO_INCREMENT,
--     cartId INT NOT NULL,
--     shoeId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (cartId)
--         REFERENCES carts(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (shoeId)
--         REFERENCES shoes(id)
--         ON DELETE CASCADE
-- )