use izdatelskii_center;

SELECT * FROM whriter;
-- SELECT * FROM whriter WHERE Number_passport LIKE '';

SELECT * FROM contract;

SELECT contract.Status 
FROM contract 
JOIN whriter ON whriter.Number_contract = contract.Number_contract
WHERE whriter.Number_passport = 740262;

SELECT * FROM book_has_whriter;
-- DELETE FROM book_has_whriter WHERE ID_BHW = 2019;
SELECT * FROM book;
-- DELETE FROM book WHERE ID_book >= 1016;


SELECT * FROM zakazchik;

SELECT * FROM book;
SELECT * FROM zakaz;

INSERT INTO zakaz VALUES(4016, '2023-11-07', '2023-11-14', '62', '1001', 3001);
DELETE FROM zakaz WHERE ID_Zakaz = 4016;

SElECT * FROM book WHERE ID_book = 1001;

SELECT Cost - Sebestoimost FROM book WHERE ID_book = 1001;
SELECT Cost - Sebestoimost, gonorar FROM book WHERE ID_book = 1001;
UPDATE book SET Gonorar = 36900 WHERE ID_book = 1001;


SELECT * FROM zakazchik;
DELETE FROM zakazchik WHERE ID_zakazchika = 3011;





SELECT book.ID_book, book.Name_book, book.Tiragh - SUM(zakaz.Count_exemplyars), book.Tiragh, SUM(zakaz.Count_exemplyars)
FROM book 
JOIN zakaz ON book.ID_book = zakaz.Book_ID_book
GROUP BY zakaz.Book_ID_book, book.Tiragh, book.ID_book
HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0;

SELECT book.Tiragh - SUM(zakaz.Count_exemplyars) 
FROM book 
JOIN zakaz ON book.ID_book = zakaz.Book_ID_book 
GROUP BY zakaz.Book_ID_book, book.Tiragh, book.Name_book  
HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0 
AND book.Name_book = 'Айболит';

SELECT ID_book
FROM book 
WHERE Name_book = 'Айболит';

SELECT MAX(ID_Zakaz)
FROM zakaz ;


SELECT book.Name_book, book.Tiragh - SUM(zakaz.Count_exemplyars), book.Tiragh, SUM(zakaz.Count_exemplyars)
FROM book 
JOIN zakaz ON book.ID_book = zakaz.Book_ID_book
GROUP BY zakaz.Book_ID_book
HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0 AND book.Name_book = 'Айболит';

