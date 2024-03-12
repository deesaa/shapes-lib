SELECT item_name, category_name
FROM dbo.Items
LEFT JOIN 
    (SELECT item_name inner_item_name, category_name
     FROM dbo.Items i, dbo.Categories c, dbo.ItemToCategory itc
     WHERE i.item_id = itc.item_id AND c.category_id = itc.category_id) b 
        ON b.inner_item_name = item_name
