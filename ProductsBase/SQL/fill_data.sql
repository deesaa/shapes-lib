GO
DROP TABLE IF EXISTS dbo.ItemToCategory
DROP TABLE IF EXISTS dbo.Categories
DROP TABLE IF EXISTS dbo.Items
DROP PROCEDURE IF EXISTS dbo.SetCategoryToItem;


CREATE TABLE dbo.Items (
    item_id INT NOT NULL IDENTITY (1, 1),
    item_name VARCHAR (255) NOT NULL,
    PRIMARY KEY (item_id)
)

CREATE TABLE dbo.Categories (
    category_id INT NOT NULL IDENTITY (1, 1),
    category_name VARCHAR (255) NOT NULL,
    PRIMARY KEY (category_id)
)

CREATE TABLE dbo.ItemToCategory (
    item_id INT,
    category_id INT,
    FOREIGN KEY (item_id) REFERENCES dbo.Items(item_id),
    FOREIGN KEY (category_id) REFERENCES dbo.Categories(category_id),
)

INSERT INTO dbo.Items(item_name) VALUES
    ('Apple'), ('Orange'), ('Cucumber'),
    ('PlayStation'), ('Laptop'), ('Xiaomiphone'),
    ('Glass'), ('Wood'), ('Diamond'),
    ('Rock'), ('Paper'), ('Scissors');

INSERT INTO dbo.Categories(category_name) VALUES
    ('Cheap'), ('Gaming'), ('MustHave');

GO;
CREATE PROCEDURE dbo.SetCategoryToItem
    @item_name VARCHAR (255), @category_name VARCHAR (255)
AS
INSERT INTO dbo.ItemToCategory(item_id, category_id)
SELECT item_id, category_id FROM dbo.Items, dbo.Categories
WHERE item_name = @item_name AND category_name = @category_name;

GO;
EXEC SetCategoryToItem @item_name = 'Apple', @category_name = 'Cheap';
EXEC SetCategoryToItem @item_name = 'Orange', @category_name = 'Cheap';
EXEC SetCategoryToItem @item_name = 'Cucumber', @category_name = 'Cheap';
EXEC SetCategoryToItem @item_name = 'Apple', @category_name = 'MustHave';
EXEC SetCategoryToItem @item_name = 'Orange', @category_name = 'MustHave';
EXEC SetCategoryToItem @item_name = 'Cucumber', @category_name = 'MustHave';

EXEC SetCategoryToItem @item_name = 'PlayStation', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'Laptop', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'Xiaomiphone', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'PlayStation', @category_name = 'MustHave';
EXEC SetCategoryToItem @item_name = 'Laptop', @category_name = 'MustHave';
EXEC SetCategoryToItem @item_name = 'Xiaomiphone', @category_name = 'MustHave';

EXEC SetCategoryToItem @item_name = 'Rock', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'Paper', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'Scissors', @category_name = 'Gaming';
EXEC SetCategoryToItem @item_name = 'Rock', @category_name = 'Cheap';
EXEC SetCategoryToItem @item_name = 'Paper', @category_name = 'Cheap';
EXEC SetCategoryToItem @item_name = 'Scissors', @category_name = 'Cheap';
