use izdatelskii_center;

INSERT INTO contract VALUES('101', '2017-05-20', '7', true, null);
INSERT INTO contract VALUES('102', '2019-12-09', '3', false, '2022-12-09');
INSERT INTO contract VALUES('103', '2016-08-08', '9', true, null);
INSERT INTO contract VALUES('104', '2012-11-27', '12', true, null);
INSERT INTO contract VALUES('105', '2022-03-09', '1', true, null);
INSERT INTO contract VALUES('106', '2015-04-16', '6', false, '2021-04-26');
INSERT INTO contract VALUES('107', '2019-02-02', '5', true, null);
INSERT INTO contract VALUES('108', '2016-10-04', '8', true, null);
INSERT INTO contract VALUES('109', '2019-06-20', '6', true, null);
INSERT INTO contract VALUES('110', '2014-01-27', '11', true, null);
INSERT INTO contract VALUES('111', '2023-05-15', '1', true, null);
INSERT INTO contract VALUES('112', '2008-03-28', '4', false, '2012-03-28');
INSERT INTO contract VALUES('113', '2020-12-09', '10', true, null);
INSERT INTO contract VALUES('114', '2023-06-23', '1', true, null);
INSERT INTO contract VALUES('115', '2022-07-04', '2', true, null);
SELECT * FROM contract;

INSERT INTO whriter VALUES('350075', 'Блок', 'Александр', 'Александрович', 'Ново-Садовая, 138', '+79062734116', '105');
INSERT INTO whriter VALUES('658303', 'Есенин', 'Сергей', 'Александрович', 'Дыбенко, 120', '+79274483413', '110');
INSERT INTO whriter VALUES('740326', 'Пушкин', 'Александр', 'Сергеевич', 'Пушкина, 223', '+79379457393', '109');
INSERT INTO whriter VALUES('730254', 'Лермонтов', 'Михаил', 'Юрьевич', 'Лукачева, 42', '+79846208775', '114');
INSERT INTO whriter VALUES('216594', 'Ахматова', 'Анна', 'Андреевна', 'Чапаевская, 32', '+79859361057', '101');
INSERT INTO whriter VALUES('820456', 'Солженицын', 'Александр', 'Исаевич', 'Партизанская, 62', '+79730165075', '111');
INSERT INTO whriter VALUES('740262', 'Горький', 'Максим', null, 'Максима Горького, 82', '+79647351225', '106');
INSERT INTO whriter VALUES('231537', 'Чуковский', 'Корней', null, 'Молодогвардейская, 207', '+79115482337', '102');
INSERT INTO whriter VALUES('111436', 'Цветаева', 'Марина', 'Ивановна', 'Венцека, 21', '+79277583009', '113');
INSERT INTO whriter VALUES('914478', 'Булгаков', 'Михаил', 'Афанасьевич', 'Нагорная, 78', '+79154463878', '108');
INSERT INTO whriter VALUES('893659', 'Тургенев', 'Иван', 'Сергеевич', 'Пятая провека, 123', '+79753827458', '115');
INSERT INTO whriter VALUES('375032', 'Крылов', 'Иван', 'Андреевич', 'Кирова, 325', '+79086341645', '104');
INSERT INTO whriter VALUES('619490', 'Фет', 'Афанасий', 'Афанасьевич', 'Шверника, 16', '+79638275903', '103');
INSERT INTO whriter VALUES('264950', 'Маяковский', 'Владимир', 'Владимирович', 'проспект Металлургов, 35', '+79749675372', '112');
INSERT INTO whriter VALUES('476937', 'Бродский', 'Иосиф', 'Александрович', 'Гагарина, 33', '+79974665648', '107');
SELECT * FROM whriter;
DELETE FROM whriter WHERE Number_passport = 111111;

INSERT INTO book VALUES('1001', 'Сборник стихов Маяковского', '123', '2009-06-11', '300', '600', '36900'); 
INSERT INTO book VALUES('1002', 'Герой нашего времени', '64', '2023-07-04', '400', '740', '21760'); 
INSERT INTO book VALUES('1003', 'Судьба и Случайности', '2414', '2021-04-04', '50', '300', '603500'); 
INSERT INTO book VALUES('1004', 'Архипилаг ГУЛАГ', '6342', '2023-07-02', '500', '800', '1902600'); 
INSERT INTO book VALUES('1005', 'Тайны Прошлого', '2341', '2023-09-29', '100', '300', '468200');
INSERT INTO book VALUES('1006', 'Мастер и Маргарита', '666', '2017-09-09', '550', '3000', '1631700');
INSERT INTO book VALUES('1007', 'Сборник басен Крылова', '2156', '2014-11-09', '200', '300', '215600');
INSERT INTO book VALUES('1008', 'Сбоник "Старана Негодяев"', '76543', '2018-01-05', '150', '200', '3827150');
INSERT INTO book VALUES('1009', 'Муха-цокотуха', '3215', '2019-12-31', '50', '300', '803750'); 
INSERT INTO book VALUES('1010', 'Отцы и дети', '65431', '2022-12-09', '450', '900', '29443950'); 
INSERT INTO book VALUES('1011', 'На дне', '777', '2019-05-03', '350', '1100', '582750');
INSERT INTO book VALUES('1012', 'Пиковая дама', '41242', '2020-01-01', '150', '400', '10310500'); 
INSERT INTO book VALUES('1013', 'Мойдодыр', '523451', '2021-12-31', '30', '300', '141331770'); 
INSERT INTO book VALUES('1014', 'Айболит', '735635', '2020-12-31', '35', '300', '194943275'); 
INSERT INTO book VALUES('1015', 'Руслан и Людмила', '5743', '2020-06-01', '200', '500', '1722900');
SELECT * FROM book;
INSERT INTO book VALUES('1016', 'Новая', '5000', '2023-11-14', '100', '200', '0');

DELETE FROM book WHERE ID_book > 1015;

INSERT INTO book_has_whriter VALUES('2001','1001','264950');
INSERT INTO book_has_whriter VALUES('2002','1002','730254');
INSERT INTO book_has_whriter VALUES('2003','1003','216594');
INSERT INTO book_has_whriter VALUES('2004','1003','111436');
INSERT INTO book_has_whriter VALUES('2005','1004','820456');
INSERT INTO book_has_whriter VALUES('2006','1005','730254');
INSERT INTO book_has_whriter VALUES('2007','1005','476937');
INSERT INTO book_has_whriter VALUES('2008','1005','740326');
INSERT INTO book_has_whriter VALUES('2009','1006','914478');
INSERT INTO book_has_whriter VALUES('2010','1007','375032');
INSERT INTO book_has_whriter VALUES('2011','1008','658303');
INSERT INTO book_has_whriter VALUES('2012','1009','231537');
INSERT INTO book_has_whriter VALUES('2013','1010','893659');
INSERT INTO book_has_whriter VALUES('2014','1011','740262');
INSERT INTO book_has_whriter VALUES('2015','1012','740326');
INSERT INTO book_has_whriter VALUES('2016','1013','231537');
INSERT INTO book_has_whriter VALUES('2017','1014','231537');
INSERT INTO book_has_whriter VALUES('2018','1015','740326');
SELECT * FROM book_has_whriter;
DELETE FROM book_has_whriter WHERE ID_BHW > 2018;



INSERT INTO zakazchik VALUES('3001','ООО Урал','Партизанская 49','+79557242982','Гаврилов Н.В.');
INSERT INTO zakazchik VALUES('3002','ОАО Маленький подросток','Тухачевского 109','+79236469954','Некрасов Д.О.');
INSERT INTO zakazchik VALUES('3003','ОО "Обсудим"','5-ая просека 109','+79252215876','Зиновьева П.Д.');
INSERT INTO zakazchik VALUES('3004','Городская библиотека','Самарская 190Б','+79222211153','Плешаков И.С.');
INSERT INTO zakazchik VALUES('3005','Школьная библиотека','Пензенская 30','+79278545325','Древенко А.Д.');
INSERT INTO zakazchik VALUES('3006','Чёрный дельфин','Аэродромная 339','+79253211454','Бородина Н.В.');
INSERT INTO zakazchik VALUES('3007','ООО Дети','Вилоновская 111','+79253290142','Калашникова П.К.');
INSERT INTO zakazchik VALUES('3008','OZON','Красноармейская 50','+79200928561','Куликов О.М.');
INSERT INTO zakazchik VALUES('3009','ООО Школково','Промышленности 24','+79242155368','Степанов Д.А.');
INSERT INTO zakazchik VALUES('3010','Мегамаркет','Крупской 101','+79224214252','Шувалов И.А.');
-- DELETE FROM zakazchik WHERE ID_zakazchika = 3011;
SELECT * FROM zakazchik;


INSERT INTO zakaz VALUES('4001', '2020-06-24', '2020-07-01', '200', '1015', '3004');
INSERT INTO zakaz VALUES('4002', '2023-09-29', '2023-10-01', '2341', '1005', '3001');
INSERT INTO zakaz VALUES('4003', '2021-09-13', '2021-09-15', '20000', '1014', '3010');
INSERT INTO zakaz VALUES('4004', '2022-12-06', '2022-12-12', '10000', '1010', '3007');
INSERT INTO zakaz VALUES('4005', '2010-01-01', '2010-01-09', '61', '1001', '3009');
INSERT INTO zakaz VALUES('4006', '2018-01-21', '2018-01-28', '2100', '1007', '3009');
INSERT INTO zakaz VALUES('4007', '2022-08-03', '2022-08-20', '1000', '1003', '3009');
INSERT INTO zakaz VALUES('4008', '2023-08-09', '2023-08-16', '5500', '1004', '3006');
INSERT INTO zakaz VALUES('4009', '2022-12-06', '2022-12-13', '10', '1010', '3005');
INSERT INTO zakaz VALUES('4010', '2022-01-07', '2022-01-10', '10000', '1013', '3008');
INSERT INTO zakaz VALUES('4011', '2021-01-21', '2021-01-26', '10000', '1014', '3008');
INSERT INTO zakaz VALUES('4012', '2021-05-10', '2021-05-15', '1000', '1003', '3002');
INSERT INTO zakaz VALUES('4013', '2022-02-01', '2022-02-04', '20000', '1014', '3010');
INSERT INTO zakaz VALUES('4014', '2018-10-01', '2018-10-05', '666', '1006', '3003');
INSERT INTO zakaz VALUES('4015', '2020-01-09', '2020-01-15', '3000', '1009', '3007');
SELECT * FROM zakaz;
SELECT * FROM book;

DELETE FROM zakaz WHERE ID_Zakaz > 4000;


SELECT book.Name_book, book.Tiragh - SUM(zakaz.Count_exemplyars) 
FROM book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book 
GROUP BY zakaz.Book_ID_book, book.Tiragh 
HAVING book.Tiragh - SUM(zakaz.Count_exemplyars) != 0;


SELECT book.Name_book AS 'Название книги', book.Sebestoimost AS 'Себестоимость, руб.', 
book.Cost AS 'Цена продажи, руб.', SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров', 
(book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.'
from book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book 
WHERE zakaz.Date_vipolnenia LIKE '2023%'
GROUP BY zakaz.Book_ID_book, book.Tiragh;

SELECT
    book.Name_book AS 'Название книги',
    book.Sebestoimost AS 'Себестоимость, руб.',
    book.Cost AS 'Цена продажи, руб.',
    SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров',
    (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.'
FROM
    book
JOIN
    zakaz ON book.ID_book = zakaz.Book_ID_book
WHERE
    zakaz.Date_vipolnenia LIKE '2010%'
GROUP BY
    zakaz.Book_ID_book, book.Tiragh
UNION
SELECT
    'Итого' AS 'Название книги',
    null AS 'Себестоимость, руб.',
    null AS 'Цена продажи, руб.',
    null AS 'Количество экземпляров',
    (
        SELECT SUM((b.Cost - b.Sebestoimost) * z.Count_exemplyars)
        FROM book b
        JOIN zakaz z ON b.ID_book = z.Book_ID_book
        WHERE z.Date_vipolnenia LIKE '2010%'
    ) AS 'Прибыль от продажи книги, руб.';




select book.Name_book as 'Название книги', book.Sebestoimost as 'Себестоимость, руб.', 
book.Cost as 'Цена продажи, руб.', book.Tiragh as 'Количество экземпляров', 
book.Gonorar as 'Прибыль от продажи книги, руб.'
from book JOIN zakaz ON book.ID_book = zakaz.Book_ID_book 
GROUP BY zakaz.Book_ID_book, book.Tiragh
order by book.Name_book;



-- 1 задание
SElECT * FROM book ORDER BY Cost; 

-- 2 задание
SELECT Status AS 'Статус', COUNT(*) AS 'Количество контрактов разных статусов'
FROM contract
GROUP BY Status;

-- 3 задание
SELECT DISTINCT Book_ID_book FROM zakaz;

-- 4 задание
SELECT Name_book AS 'Прибыльные книги', Gonorar FROM book WHERE Gonorar > 1000000;

-- 5 задание
SELECT ID_Zakaz, Date_vipolnenia, Count_exemplyars FROM zakaz 
WHERE Date_vipolnenia LIKE '2023%' AND Count_exemplyars BETWEEN 1000 AND 9999;

-- 6 задание
SELECT avg(Count_exemplyars) FROM zakaz;
SELECT sum(Count_exemplyars) AS 'Сумма экземпляров книги', 
Book_ID_book  AS 'ID книги, сумма экземпляров которой больше среднего количества экземпляров по книгам' 
FROM zakaz 
GROUP BY Book_ID_book 
HAVING sum(Count_exemplyars) > (SELECT avg(Count_exemplyars) FROM zakaz);

-- 7 задание
SELECT whriter.Surname, book.Name_book
FROM whriter
JOIN book_has_whriter ON whriter.Number_passport = book_has_whriter.Whriter_Number_passport
JOIN book ON book_has_whriter.ID_book = book.ID_book;

-- 8 задание
SELECT whriter.Surname, book.Name_book, zakaz.ID_Zakaz, zakazchik.Name_zakazchik
FROM whriter
JOIN book_has_whriter ON whriter.Number_passport = book_has_whriter.Whriter_Number_passport
JOIN book ON book_has_whriter.ID_book = book.ID_book
LEFT JOIN zakaz ON zakaz.Book_ID_book = book.ID_book
LEFT JOIN zakazchik ON zakaz.Zakazchik_ID_zakazchika = zakazchik.ID_zakazchika;

-- 9 задание
SELECT book.Name_book, zakazchik.Name_zakazchik, zakaz.Count_exemplyars, book.Tiragh
FROM book
LEFT JOIN zakaz ON zakaz.Book_ID_book = book.ID_book
LEFT JOIN zakazchik ON zakaz.Zakazchik_ID_zakazchika = zakazchik.ID_zakazchika
UNION
SELECT book.Name_book, zakazchik.Name_zakazchik, zakaz.Count_exemplyars, book.Tiragh
FROM book
RIGHT JOIN zakaz ON zakaz.Book_ID_book = book.ID_book
RIGHT JOIN zakazchik ON zakaz.Zakazchik_ID_zakazchika = zakazchik.ID_zakazchika;

-- DELETE FROM zakazchik WHERE ID_zakazchika > 3005;


SELECT 
zakazchik.Name_zakazchik AS 'Заказчик',
     book.Name_book AS 'Название книги',
     book.Sebestoimost AS 'Себестоимость, руб.',
     book.Cost AS 'Цена продажи, руб.',
     SUM(zakaz.Count_exemplyars) AS 'Количество экземпляров',
     (book.Cost - book.Sebestoimost) * SUM(zakaz.Count_exemplyars) AS 'Прибыль от продажи книги, руб.'
 FROM
     book
 JOIN
     zakaz ON book.ID_book = zakaz.Book_ID_book
 JOIN
     zakazchik ON zakazchik.ID_zakazchika = zakaz.Zakazchik_ID_zakazchika   
 WHERE
     zakaz.Date_vipolnenia LIKE '2023%'
 GROUP BY
     zakazchik.Name_zakazchik, zakaz.Book_ID_book, book.Tiragh
 
 UNION
 SELECT
     'Итого' AS 'Заказчик',
  null AS 'Название книги',
     null AS 'Себестоимость, руб.',
     null AS 'Цена продажи, руб.',
     null AS 'Количество экземпляров',
     (
         SELECT SUM((b.Cost - b.Sebestoimost) * z.Count_exemplyars)
         FROM book b
         JOIN zakaz z ON b.ID_book = z.Book_ID_book
         WHERE z.Date_vipolnenia LIKE '2023%'
     ) AS 'Прибыль от продажи книги, руб.'