use horse_racing;

insert into horse_owher values('1001', 'Дмитрий', '5-я просека 125', '+79793658254');
insert into horse_owher values('1002', 'Илья', 'Центральная 15', '+79738492319');
insert into horse_owher values('1003', 'Полина', 'Гая 167', '+79097410537');
insert into horse_owher values('1004', 'Нина', 'Победы 45', '+79638107352');
insert into horse_owher values('1005', 'Валерий', 'Металлургов 98', '+79748211053');
insert into horse_owher values('1006', 'Александр', 'Авроры 7', '+79745284026');
insert into horse_owher values('1007', 'Кирилл', 'Самарская 12', '+79074527488');
insert into horse_owher values('1008', 'Александр', 'Панова 34', '+79648823168');
insert into horse_owher values('1009', 'Павел', 'Полевая 16', '+79647736767');
insert into horse_owher values('1010', 'Александр', 'Дыбенко', '+79795678934');
select * from horse_owher;
-- DELETE FROM horse_owher WHERE id_owher >= 1000;

insert into horse values('201', 'Стрелка', 'ж', '3', '1001');
insert into horse values('202', 'Черная стрела', 'ж', '2', '1009');
insert into horse values('203', 'Гром', 'м', '5', '1010');
insert into horse values('204', 'Мустанг', 'м', '4', '1001');
insert into horse values('205', 'Рубин', 'м', '3', '1008');
insert into horse values('206', 'Вихрь', 'м', '2', '1002');
insert into horse values('207', 'Граф', 'м', '4', '1001');
insert into horse values('208', 'Энни', 'ж', '3', '1004');
insert into horse values('209', 'Инжир', 'м', '2', '1003');
insert into horse values('210', 'Чарли', 'ж', '4', '1004');
insert into horse values('211', 'Алтай', 'м', '3', '1005');
insert into horse values('212', 'Рей', 'м', '2', '1008');
insert into horse values('213', 'Дина', 'ж', '2', '1007');
insert into horse values('214', 'Марсель', 'м', '3', '1006');
insert into horse values('215', 'Лаванда', 'ж', '4', '1009');
select * from horse;
-- insert into horse values('220', 'GGGGG', 'женский', '3', '1001');


insert into jockey values('2001', 'Иван', 'Масленникова 12', '21', 5);
insert into jockey values('2002', 'Дмитрий', 'Пролетарская 165', '23', 2);
insert into jockey values('2003', 'Иван', '5-я просека 125', '31', 4);
insert into jockey values('2004', 'Алексей', '5-я просека 125', '18', 4);
insert into jockey values('2005', 'Елена', 'Ставропольская 65', '26', 3);
insert into jockey values('2006', 'Андрей', 'Скляренко 2', '21', 4);
insert into jockey values('2007', 'Роман', 'Дачная 18', '25', 5);
insert into jockey values('2008', 'Денис', 'Мичурина 55', '19', 5);
insert into jockey values('2009', 'Никита', 'Владимирская 65', '19', 3);
insert into jockey values('2010', 'Мария', 'Ульяновская 47', '22', 4);
insert into jockey values('2011', 'Ольга', 'Рабочая 143', '21', 5);
insert into jockey values('2012', 'Валентин', 'Ленинская 4', '25', 5);
select * from jockey;


insert into competition values('01', '2023-04-24', '14:00', 'Самара', 'Чемпионат мира');
insert into competition values('02', '2023-06-13', '13:00', 'Сочи', 'Конкурный бум');
insert into competition values('03', '2023-03-05', '14:30', 'Москва', 'Кубок Москвы');
insert into competition values('04', '2023-07-28', '14:30', 'Токио', 'Японский конный кубок');
insert into competition values('05', '2023-05-15', '13:30', 'Кентукки', 'Дерби Кентукки');
insert into competition values('06', '2023-06-09', '13:00', 'Санкт-Петербург', 'Кубок Победы');
insert into competition values('07', '2023-07-24', '14:00', 'Москва', 'Кубок Федерации конного спорта России');
select * from competition;


insert into race values('10001', '2', '213', '2009', '3', '00:01:23', '03');
insert into race values('10002', '2', '201', '2004', '1', '00:01:15', '03');
insert into race values('10003', '2', '205', '2010', '4', '00:01:24', '03');
insert into race values('10004', '2', '207', '2003', '2', '00:01:17', '03');

insert into race values('10006', '1', '208', '2005', '2', '00:01:36', '03');
insert into race values('10005', '1', '202', '2004', '1', '00:01:35', '03');
insert into race values('10009', '1', '215', '2001', '3', '00:01:38', '03');
insert into race values('10007', '3', '213', '2009', '2', '00:01:40', '03');
insert into race values('10008', '3', '212', '2007', '1', '00:01:36', '03');

insert into race values('10010', '3', '201', '2012', '2', '00:01:45', '06');
insert into race values('10011', '1', '208', '2005', '1', '00:01:42', '06');
insert into race values('10012', '1', '214', '2011', '2', '00:01:45', '06');
insert into race values('10013', '2', '211', '2002', '2', '00:01:44', '06');
insert into race values('10014', '2', '206', '2006', '1', '00:01:41', '06');

insert into race values('10015', '2', '211', '2002', '3', '00:01:55', '04');
insert into race values('10016', '1', '202', '2004', '2', '00:01:57', '04');

select * from race;
-- DELETE FROM race WHERE id_race >= 10000;


/* 1 задание
Для заданной лошади найти все соревнования в которых она принимала участие, 
указать номер заезда и результат ее заезда.*/

select horse.nickname as 'Кличка лошади', competition.name_competition as 'Название соревнования',
race.race_number as 'Номер заезда', race.race_place as 'Место в заезде', race.race_time as 'Время в заезде'
from horse, race, competition 
where race.horse = horse.id_horse
and race.id_competition = competition.id_competition
and horse.nickname = 'Дина';

select horse.nickname as 'Кличка лошади', competition.name_competition as 'Название соревнования',
race.race_number as 'Номер заезда', race.race_place as 'Место в заезде', race.race_time as 'Время в заезде'
from horse, race, competition 
where race.horse = horse.id_horse
and race.id_competition = competition.id_competition
and horse.nickname = 'Черная стрела';

/* 2 задание
Выдать список владельцев, имеющих более 2-х лошадей.*/
select horse_owher.id_owher, horse_owher.name as 'Владедец, имеющий более 2-х лошадей', count(*) as 'Количество лошадей'
from horse_owher, horse
where horse.owher = horse_owher.id_owher
group by horse_owher.id_owher
having count(*) >= 2;

/* 3 задание
Выдать список соревнований в которых принимали участие не менее 4-х жокеев 
с заданным уровнем рейтинга.*/
select competition.name_competition as 'Название соревнования',  count(*) as 'Количество жокеев в заезде',
jockey.rating as 'Рейтинг'
from competition, race, jockey 
where race.jockey = jockey.id_jockey
and race.id_competition = competition.id_competition
and jockey.rating = 4
group by race.id_competition, jockey.rating
having count(*) >= 4;

/* 4 задание
 За указанный период выдать список состязаний в хронологическом порядке с 
указанием количества заездов в них.*/

-- без ограничения даты
select subquery.name_competition as 'Название соревнования', count(*) as'Количество заездов в соревновании', 
subquery.date as 'Дата соревнования', subquery.time as 'Время соревнования'
from (select competition.name_competition, race.race_number, competition.date, competition.time
	from race, competition 
	where race.id_competition = competition.id_competition
	group by race.race_number, competition.name_competition, competition.date, competition.time
    order by competition.date, competition.time
    ) as subquery
group by subquery.name_competition, subquery.date, subquery.time;


select subquery.name_competition as 'Название соревнования', count(*) as'Количество заездов в соревновании', 
subquery.date as 'Дата соревнования', subquery.time as 'Время соревнования'
from (select competition.name_competition, race.race_number, competition.date, competition.time
	from race, competition 
	where race.id_competition = competition.id_competition
	group by race.race_number, competition.name_competition, competition.date, competition.time
    order by competition.date, competition.time
    ) as subquery
group by subquery.name_competition, subquery.date, subquery.time
having subquery.date between '2023-06-01' and '2023-08-31';

/* 5 задание
Выдать список состязаний и номеров заездов, в которых лошадь «Черная стрела» 
заняла 1 место.*/
select competition.name_competition as 'Название соревнования', race.race_number as 'Номер заезда', 
race.race_place as 'Место в заезде', horse.nickname as 'Кличка лошади'
from competition, race, horse 
where race.horse = horse.id_horse
and race.id_competition = competition.id_competition
and horse.nickname = 'Черная стрела'
and race.race_place = '1';


