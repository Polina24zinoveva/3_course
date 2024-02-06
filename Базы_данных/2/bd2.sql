use session_results;

INSERT INTO student VALUES('124', 'Zinoveva', 'Polina', 'Dmitrievna', '2003-04-24');
INSERT INTO student VALUES('123', 'Bobrova', 'Maria', 'Cergeevna', '2003-07-23');
INSERT INTO student VALUES('109', 'Shashkina', 'Alyona', 'Alekseevna', '2003-10-09');
INSERT INTO student VALUES('118', 'Grishkova', 'Viktoria', 'Aleksandrovna', '2003-07-18');
INSERT INTO student VALUES('106', 'Ivanov', 'Ivan', 'Mikhaylovich', '2003-02-06');
INSERT INTO student VALUES('128', 'Smirnov', 'Vladimir', 'Alecsandrovich', '2003-07-28');
INSERT INTO student VALUES('121', 'Nikolaev', 'Dmitriy', 'Borisovich', '2003-12-20');
select * from student;

INSERT INTO teacher VALUES('015', 'Archibasov', 'Aleksey', 'Alekseevich');
INSERT INTO teacher VALUES('030', 'Sopchenko', 'Elena', 'Bilievna');
INSERT INTO teacher VALUES('021', 'Zavershinskiy', 'Dmitriy', 'Igorevich');
select * from teacher;


INSERT INTO subject VALUES('1106', 'Matematicheskiy_analis', '3', '015');
INSERT INTO subject VALUES('1117', 'Programmirovanie', '1', '030');
INSERT INTO subject VALUES('1162', 'EVM', '3', '030');
INSERT INTO subject VALUES('1081', 'Phisics', '4', '021');
select * from subject;

INSERT INTO grade VALUES('124', '1106', '5');
INSERT INTO grade VALUES('124', '1117', '5');
INSERT INTO grade VALUES('124', '1162', '5');
INSERT INTO grade VALUES('124', '1081', '5');
INSERT INTO grade VALUES('118', '1106', '4');
INSERT INTO grade VALUES('118', '1162', '5');
INSERT INTO grade VALUES('118', '1081', '5');
INSERT INTO grade VALUES('106', '1106', '3');
INSERT INTO grade VALUES('106', '1117', '4');
INSERT INTO grade VALUES('106', '1081', '4');
INSERT INTO grade VALUES('121', '1081', '4');
select * from grade;



UPDATE student SET date_of_birth ='2003-12-21' WHERE number_zachethoy_knishki =121;
select * from student;
DELETE FROM student WHERE number_zachethoy_knishki='121';
select * from student;


select * from subject;
SELECT DISTINCT name_subject as Название_предмета FROM subject ORDER BY name_subject;

SELECT COUNT(*) FROM student;

SELECT surname as Фамилии_студентов_начинающиеся_на_Ива FROM student WHERE surname LIKE 'Iva%';

SELECT student.surname FROM student, subject, grade 
WHERE student.number_zachethoy_knishki = grade.student 
AND grade.subject = subject.id_subject 
AND subject.name_subject='Phisics' AND grade.grade = 5 
ORDER BY student.surname DESC;

SELECT student.surname, SUM(grade.grade) 
FROM student 
JOIN grade ON student.number_zachethoy_knishki = grade.student 
JOIN subject ON grade.subject = subject.id_subject 
WHERE subject.name_subject IN('Phisics', 'Matematicheskiy_analis', 'EVM') 
GROUP BY student.number_zachethoy_knishki 
HAVING SUM(grade.grade) > 12;