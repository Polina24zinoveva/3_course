use accounting;

INSERT INTO type_podrazdelenia VALUES('001', 'отдел');
INSERT INTO type_podrazdelenia VALUES('002', 'служба');
INSERT INTO type_podrazdelenia VALUES('003', 'управление');
INSERT INTO type_podrazdelenia VALUES('004', 'департамент');
select * from type_podrazdelenia;

INSERT INTO podrazdelenie VALUES('101', 'кафедра физики', '001');
INSERT INTO podrazdelenie VALUES('102', 'кафедра программных систем', '001');
INSERT INTO podrazdelenie VALUES('103', 'кафедра биологии', '001');
INSERT INTO podrazdelenie VALUES('104', 'центр здоровья и фитнеса', '002');
INSERT INTO podrazdelenie VALUES('105', 'центр предпренимательства и инноваций', '002');
INSERT INTO podrazdelenie VALUES('106', 'управление академическим процессом', '003');
INSERT INTO podrazdelenie VALUES('107', 'управление общежитиями', '003');
INSERT INTO podrazdelenie VALUES('108', 'департамент дистанционного обучения', '004');

select * from podrazdelenie;

INSERT INTO equipment VALUES('1001', 'штангельциркуль', '300', '101', true);
INSERT INTO equipment VALUES('1002', 'амперметр', '500', '101', false);
INSERT INTO equipment VALUES('1003', 'вольтметр', '500', '101', false);
INSERT INTO equipment VALUES('1004', 'монитор', '10000', '102', false);
INSERT INTO equipment VALUES('1005', 'системный блок', '10000', '102', false);
INSERT INTO equipment VALUES('1006', 'мышь компьютерная', '500', '102', true);
INSERT INTO equipment VALUES('1007', 'клавиатура', '1000', '102', false);
INSERT INTO equipment VALUES('1008', 'микроскоп', '10440', '103', false);
INSERT INTO equipment VALUES('1009', 'халат', '400', '103', true);
INSERT INTO equipment VALUES('1010', 'мяч волейбольный', '500', '104', false);
INSERT INTO equipment VALUES('1011', 'секундомер', '200', '104', false);
INSERT INTO equipment VALUES('1012', 'проектор', '7000', '105', false);
INSERT INTO equipment VALUES('1013', 'принтер', '4000', '106', false);
INSERT INTO equipment VALUES('1014', 'швабра', '500', '107', true);
INSERT INTO equipment VALUES('1015', 'микрофон', '200', '108', false);
select * from equipment;

UPDATE equipment SET name_equipment = 'системный блок' WHERE id_equipment =1005;


INSERT INTO responsible_person VALUES('501', 'Завершинский', 'Дмитрий', 'Игоревич', '101');
INSERT INTO responsible_person VALUES('502', 'Востокин', 'Сергей', 'Владимирович', '102');
INSERT INTO responsible_person VALUES('503', 'Писарева', 'Елена', 'Владимировна', '103');
INSERT INTO responsible_person VALUES('504', 'Борисов', 'Александр', 'Яковлевич', '104');
INSERT INTO responsible_person VALUES('505', 'Иванов', 'Алексей', 'Михайлович', '105');
INSERT INTO responsible_person VALUES('506', 'Соловова', 'Наталья', 'Валентиновна', '106');
INSERT INTO responsible_person VALUES('507', 'Батров', 'Владимир', 'Геннадьевич', '107');
INSERT INTO responsible_person VALUES('508', 'Бобров', 'Михаил', 'Сергеевич', '108');
select * from responsible_person;

/*SELECT podrazdelenie.id_podrazdelenia, podrazdelenie.name_podrazdelenia, 
type_podrazdelenia.name_type_podrazdelenia, responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM podrazdelenie, responsible_person, type_podrazdelenia 
WHERE podrazdelenie.type_podrazdelenia = type_podrazdelenia.id_type_podrazdelenia
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia;*/

-- 3.1 задание
SELECT equipment.name_equipment, equipment.written_off, 
responsible_person.surname_person, responsible_person.name_person, 
responsible_person.middle_name_person
FROM equipment, responsible_person, podrazdelenie 
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false;

SELECT equipment.name_equipment, equipment.written_off, 
responsible_person.surname_person, responsible_person.name_person, 
responsible_person.middle_name_person
FROM equipment, responsible_person, podrazdelenie 
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false 
AND responsible_person.surname_person = 'Завершинский';

-- 3.2 задание
SELECT SUM(equipment.price), responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM equipment, podrazdelenie, responsible_person
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false
GROUP BY responsible_person.id_responsible_person;

SELECT SUM(equipment.price), responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM equipment, podrazdelenie, responsible_person
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false AND responsible_person.surname_person = 'Востокин'
GROUP BY responsible_person.id_responsible_person;

-- 3.3 задание
SELECT equipment.name_equipment, equipment.written_off, 
podrazdelenie.name_podrazdelenia
FROM equipment, podrazdelenie 
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false;

SELECT equipment.name_equipment, equipment.written_off, 
podrazdelenie.name_podrazdelenia
FROM equipment, podrazdelenie 
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false 
AND podrazdelenie.name_podrazdelenia = 'кафедра физики';

-- 3.4 задание
SELECT podrazdelenie.name_podrazdelenia
FROM equipment 
JOIN podrazdelenie ON equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
GROUP BY podrazdelenie.id_podrazdelenia
HAVING sum(NOT equipment.written_off) = false;

-- 3.5 задание
SELECT equipment.name_equipment, podrazdelenie.name_podrazdelenia, responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM equipment, podrazdelenie, responsible_person
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = true;

-- 3.6 задание
SELECT SUM(equipment.price), responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM equipment, podrazdelenie, responsible_person
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false
GROUP BY responsible_person.id_responsible_person
HAVING sum(equipment.price) > (SELECT max(price) FROM equipment);
    
-- 3.7 задание
SELECT SUM(equipment.price), podrazdelenie.name_podrazdelenia
FROM equipment, podrazdelenie
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND equipment.written_off = false
GROUP BY podrazdelenie.id_podrazdelenia;

SELECT SUM(equipment.price), podrazdelenie.name_podrazdelenia
FROM equipment, podrazdelenie
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia 
AND equipment.written_off = false AND podrazdelenie.name_podrazdelenia = 'кафедра программных систем'
GROUP BY podrazdelenie.id_podrazdelenia;


-- 4.1 задание
SELECT podrazdelenie.id_podrazdelenia AS 'ID подразделения', 
podrazdelenie.name_podrazdelenia AS 'Подразделение',
type_podrazdelenia.name_type_podrazdelenia AS 'Тип подразделения',
CONCAT(responsible_person.surname_person, ' ',
responsible_person.name_person, ' ', responsible_person.middle_name_person) AS 'ФИО материально ответственного лица'
FROM podrazdelenie, responsible_person, type_podrazdelenia 
WHERE podrazdelenie.type_podrazdelenia = type_podrazdelenia.id_type_podrazdelenia
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
ORDER BY podrazdelenie.id_podrazdelenia;

-- 4.2 задание
SELECT type_podrazdelenia.name_type_podrazdelenia AS 'Тип подразделения',
SUM(equipment.price) AS 'Сумма стоимости всего оборудования по типам подразделений'
FROM podrazdelenie, type_podrazdelenia, equipment
WHERE podrazdelenie.type_podrazdelenia = type_podrazdelenia.id_type_podrazdelenia
AND equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
GROUP BY type_podrazdelenia.id_type_podrazdelenia
ORDER BY type_podrazdelenia.name_type_podrazdelenia;


-- 4.3 задание
SELECT DISTINCT name_type_podrazdelenia AS 'Тип подразделения' FROM type_podrazdelenia;

-- 4.4 задание
SELECT name_equipment AS 'Несписанное оборудование со стоимостью больше 5000 рублей', 
price FROM equipment
WHERE written_off = false AND price > 5000;

-- 4.5 задание
SELECT surname_person, name_person, middle_name_person FROM responsible_person
WHERE surname_person LIKE 'Б%';

-- 4.6 задание
SELECT type_podrazdelenia.name_type_podrazdelenia AS 'Тип подразделения',
SUM(equipment.price) AS 'Оборудование со стоимостью больше 5000 рублей по типам подразделений'
FROM podrazdelenie, type_podrazdelenia, equipment
WHERE podrazdelenie.type_podrazdelenia = type_podrazdelenia.id_type_podrazdelenia
AND equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
GROUP BY type_podrazdelenia.id_type_podrazdelenia
HAVING SUM(price) > 5000;

-- 4.7 задание
SELECT equipment.name_equipment, equipment.written_off
FROM podrazdelenie, equipment
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND equipment.written_off = false AND podrazdelenie.type_podrazdelenia = 001;

-- 4.8 задание
SELECT equipment.name_equipment, podrazdelenie.name_podrazdelenia,  responsible_person.surname_person, 
responsible_person.name_person, responsible_person.middle_name_person
FROM equipment
INNER JOIN podrazdelenie ON equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
LEFT JOIN responsible_person ON responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia;

-- 4.9 задание
SELECT id_type_podrazdelenia AS 'Занятые id' FROM type_podrazdelenia
UNION
SELECT id_podrazdelenia FROM podrazdelenie
UNION
SELECT id_responsible_person FROM responsible_person
UNION
SELECT id_equipment FROM equipment;

-- 4.10 задание
SELECT name_equipment AS 'Название оборудования, не принадлежащего кафедре программных систем, цена которого выше среднего арифметического', 
price AS 'Цена', id_podrazdelenia  FROM equipment
WHERE id_podrazdelenia != (SELECT id_podrazdelenia FROM podrazdelenie 
WHERE name_podrazdelenia = 'кафедра программных систем')
GROUP BY id_equipment
HAVING price > (SELECT SUM(price)/count(price) FROM equipment);

-- 4.11 задание
SELECT * FROM equipment
WHERE id_podrazdelenia > ALL(SELECT id_podrazdelenia FROM podrazdelenie 
WHERE name_podrazdelenia = 'кафедра программных систем');

SELECT * FROM equipment
WHERE id_podrazdelenia > ANY(SELECT id_podrazdelenia FROM podrazdelenie 
WHERE name_podrazdelenia = 'кафедра программных систем');


SELECT * FROM responsible_person
WHERE EXISTS (SELECT * FROM podrazdelenie WHERE
responsible_person.id_podrazdelenia=podrazdelenie.id_podrazdelenia);