:-use_module(library(http/http_server)).
:-use_module(library(http/http_dispatch)).
:-use_module(library(http/http_parameters)).
:-use_module(library(http/html_write)).
:-use_module(library(http/http_error)).

%библиотека для полного стектрейса ошибок
:- use_module(library(http/http_error)).

% хэндлер для корневой страницы
:- http_handler(root(.), home_page, []).
%хэндлер страницы для добавления нового требования
:- http_handler(root(add_requirements_page), add_requirements_page, []).
%хэндлер для добавления нового требования
:- http_handler(root(add_requirements), add_requirements, [method(post)]).
%хэндлер страницы для удаления требования
:- http_handler(root(delete_requirements_p), delete_requirements_p, []).
%хэндлер для удаления требования
:- http_handler(root(delete_requirements), delete_requirements, [method(post)]).
%хэндлер для ресета БД
:- http_handler(root(reset_DB), reset_DB, [method(post)]).

% Определение хэндлеров для различных запросов
:- http_handler(root(task_1), task_1_page, []).
:- http_handler(root(task_2), task_2_page, []).
:- http_handler(root(task_3), task_3_page, []).
:- http_handler(root(task_3_S), task_3_page_S, []).
:- http_handler(root(task_4), task_4_page, []).
:- http_handler(root(task_5), task_5_page, []).
:- http_handler(root(task_5_V), task_5_page_V, []).
:- http_handler(root(stop), stop, []).


:- dynamic job_vacancy/5.
:- dynamic job_seeker/3.
:- dynamic requirements/6.


%Запуск сервера
server(Port):- http_server(http_dispatch, [port(Port)]).
server:-server(8080).

%остановка сервера
stop(Port):- http_stop_server(Port, http_dispatch).
stop:- stop(8080).


%инициализация базы фактов
reset_DB(_):-
    retractall(job_vacancy(_, _, _, _, _)),
    retractall(job_seeker(_, _, _)),
    retractall(requirements(_, _, _, _, _, _)),

    %инициализация БД
    %Требования к соискателю и соответствие требованиям могут быть описаны одной структурой: образование, возраст, пол, владение иностранными языками, умение работать на ПК, стаж работы по специальности.
    asserta(requirements('Высшее', 35, 'Мужской', 'Да', 'Да', 3)),
    asserta(requirements('Высшее', 35, 'Женский', 'Да', 'Да', 3)),
    asserta(requirements('Высшее', 30, 'Мужской', 'Нет', 'Да', 2)),
    asserta(requirements('Высшее', 25, 'Мужской', 'Да', 'Нет', 0)),
    asserta(requirements('Высшее', 25, 'Женский', 'Да', 'Нет', 0)),
    asserta(requirements('Среднее специальное', 25, 'Женский', 'Нет', 'Нет', 1)),
    asserta(requirements('Среднее специальное', 20, 'Мужской', 'Нет', 'Нет', 0)),
    asserta(requirements('Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0)),

    %asserta(requirements('О', 40, 'Нет', 'Нет', 'Нет', 0)),




    %Каждый соискатель может быть описан структурой: фамилия, имя отчество, соответствие требованиям.
    asserta(job_seeker('Петрова', 'А.К.', ['Среднее специальное', 20, 'Мужской', 'Нет', 'Да', 1])),
    asserta(job_seeker('Сидоров', 'М.А.', ['Высшее', 25, 'Мужской', 'Да', 'Да', 0])),
    asserta(job_seeker('Комарова', 'Д.Д.', ['Среднее специальное', 25, 'Женский', 'Да', 'Нет', 1])),
    asserta(job_seeker('Смирнова', 'В.М.', ['Среднее специальное', 20, 'Женский', 'Да', 'Да', 0])),
    asserta(job_seeker('Александров', 'Р.Д.', ['Высшее', 35, 'Мужской', 'Да', 'Да', 5])),
    asserta(job_seeker('Зайцев', 'А.В.', ['Высшее', 30, 'Мужской', 'Да', 'Да', 3])),
    asserta(job_seeker('Никитина', 'В.Т.', ['Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0])),
    asserta(job_seeker('Григорьев', 'И.К.', ['Высшее', 25, 'Мужской', 'Да', 'Да', 1])),



    %Каждая вакансия может быть описана структурой: название предприятия, должность, ежемесячный доход, требования к соискателю, список соискателей.
    asserta(job_vacancy('ЗИМ', 'Проектировщик', 50000, ['Высшее', 30, 'Мужской', 'Нет', 'Да', 2], [['Зайцев', 'А.В.', ['Высшее', 30, 'Мужской', 'Да', 'Да', 3]]])),

    asserta(job_vacancy('БКК', 'Кондитер', 40000, ['Среднее специальное', 25, 'Женский', 'Нет', 'Нет', 1], [['Комарова', 'Д.Д.', ['Среднее специальное', 25, 'Женский', 'Нет', 'Нет', 1]]])),

     asserta(job_vacancy('БКК', 'Продавец', 30000, ['Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0],
                        [['Петрова', 'А.К.', ['Среднее специальное', 20, 'Мужской', 'Нет', 'Да', 1]],
                         ['Никитина', 'В.Т.', ['Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0]]])),


    asserta(job_vacancy('Прогресс', 'Конструктор', 70000, ['Высшее', 35, 'Мужской', 'Да', 'Да', 3],
                        [['Александров', 'Р.Д.', ['Высшее', 35, 'Нет', 'Да', 'Да', 5]]])),

    asserta(job_vacancy('Медгард', 'Терапевт', 40000,
                        ['Высшее', 25, 'Мужской', 'Да', 'Нет', 0],
                        [['Сидоров', 'М.А.', ['Высшее', 25, 'Нет', 'Да', 'Да', 0]],
                         ['Григорьев', 'И.К.', ['Высшее', 25, 'Нет', 'Да', 'Да', 1]]])),

    asserta(job_vacancy('Ашан', 'Продавец', 30000,
                        ['Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0],
                        [['Петрова', 'А.К.', ['Среднее специальное', 20, 'Мужской', 'Нет', 'Да', 1]],
                         ['Смирнова', 'В.М.', ['Среднее специальное', 20, 'Женский', 'Да', 'Да', 0]],
                         ['Никитина', 'В.Т.', ['Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0]]])),

http_redirect(moved, '/', _Request).


%Обработка главной страницы
home_page(_Request):-
    %Собираем столбцы в список
    findall(Education, requirements(Education, _, _, _, _, _), Educations),
    findall(Age, requirements(_, Age, _, _, _, _), Ages),
    findall(Gender, requirements(_, _, Gender, _, _, _), Genders),
    findall(Language, requirements(_, _, _, Language, _, _), Languages),
    findall(Computer, requirements(_, _, _, _, Computer, _), Computers),
    findall(Experience, requirements(_, _, _, _, _, Experience), Experiences),


    %Добавляем заголовки таблицы
    generate_rows6(Educations, Ages, Genders, Languages, Computers, Experiences, Rows1),
    ins(Rows1, tr(
                  [
                    th('Образование'),
                    th('Возраст'),
                    th('Пол'),
                    th('Знание иностранного языка'),                            th('Умение работать на ПК'),                                th('Опыт')

                  ]
              ), Rows_with_Headers1),




    %Собираем столбцы в список
    findall(Surname, job_seeker(Surname, _, _), Surnames),
    findall(Name, job_seeker(_, Name, _), Names),
    findall(Requirement_r, job_seeker(_, _, Requirement_r), Requirements_r),


    %Добавляем заголовки таблицы
    generate_rows_r(Surnames, Names, Requirements_r, Rows_r),
    ins(Rows_r, tr(
                  [
                    th('Фамилия'),
                    th('Имя Отчество'),
                    th('Требования')]
              ), Rows_with_Headers_r),



    %Собираем столбцы в список
    findall(Company, job_vacancy(Company, _, _, _, _), Companys),
    findall(Vacancy, job_vacancy(_, Vacancy, _, _, _), Vacancys),
    findall(Salary, job_vacancy(_, _, Salary, _, _), Salarys),
    findall(Requirement, job_vacancy(_, _, _, Requirement, _), Requirements),
    findall(Seeker, job_vacancy(_, _, _, _, Seeker), Seekers),
    %Добавляем заголовки таблицы
    generate_rows(Companys, Vacancys, Salarys, Requirements,Seekers, Rows),
    ins(Rows, tr(
                  [
                    th('Компания'),
                    th('Вакансия'),
                    th('Зарплата'),
                    th('Требования')
,                   th('Соискатели')

                  ]
              ), Rows_with_Headers3),



    reply_html_page(
        title('Лабораторная работа 3. Выполнила Зиновьева Полина'),
        [
            h1('Лабораторная работа 3. Выполнила Зиновьева Полина'),

            h2('Биржа труда'),

            h2('Поисковые запросы:'),
            ul([
                li(a([href('/task_1')], 'Найти должность, для которой существует максимальное число соискателей')),
                li(a([href('/task_2')], ' Найти все должности для мужчин, с высшим образованием и свободно владеющих иностранным языком')),
                li(a([href('/task_3')], 'Найти все предприятия, предлагающие доход выше указанного уровня')),
                li(a([href('/task_4')], 'Найти всех соискателей, умеющих работать на ПК, и имеющих стаж работы более 5 лет')),
                li(a([href('/task_5')], 'Подсчитать число предприятий, у которых есть заданная вакансия'))
            ]),

            h3('Таблица требований'),
            table(
                [border(2)],
                Rows_with_Headers1
            ),

            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/add_requirements_page')], 'Добавить требование'))
            ),
            form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/delete_requirements_p')], 'Удалить требование'))
            ),
            form(
                [style('display: inline-block'),  method(post)],
                p(button([type(submit), formaction(location_by_id('reset_DB'))], 'Сбросить БД'))
            ),

            h3('Таблица соискателей'),
            table(
                [border(2)],
                Rows_with_Headers_r
            ),


            h3('Таблица вакансий'),
            table(
                [border(2)],
                Rows_with_Headers3
            )

        ]

    ).

%Добавление элемента в начало списка
ins(L, El, [El|L]).

% Генерация строк таблицы для требований
generate_rows6([], [], [], [], [], [], []).
generate_rows6([Education|Educations], [Age|Ages], [Gender|Genders], [Language|Languages], [Computer|Computers], [Experience|Experiences], [tr([td(Education), td(Age), td(Gender), td(Language), td(Computer), td(Experience)])|Rows1]):-
    generate_rows6(Educations, Ages, Genders, Languages, Computers, Experiences, Rows1).



% Генерация строк таблицы для требований
generate_rows_r([], [], [], []).
generate_rows_r([Surname|Surnames], [Name|Names], [Requirement_r|Requirements_r], [tr([td(Surname), td(Name), td(ReqStr)])|Rows_r]):-
    format(atom(ReqStr), '~q', [Requirement_r]),
    generate_rows_r(Surnames, Names, Requirements_r, Rows_r).



%Генерация строк таблицы
generate_rows([], [], [], [], [], []).
generate_rows([Company|Companys], [Vacancy|Vacancys], [Salary|Salarys], [Requirement|Requirements], [Seeker|Seekers], [tr([td(Company), td(Vacancy), td(Salary), td(ReqStr), td(SeekerStr)])|Rows]):-
    format(atom(ReqStr), '~q', [Requirement]),
    format(atom(SeekerStr), '~q', [Seeker]),
    generate_rows(Companys, Vacancys, Salarys, Requirements, Seekers, Rows).



%Страница с добавлением новой вакансии
add_requirements_page(_Request):-
    reply_html_page(
        title('Добавление требование'),
        [form(
            [action=location_by_id(add_requirements), method(post)],
            [
                h3('Добавление требования:'),
                table([
                    tr([th('Образование'), td(input([name(education)]))]),
                    tr([th('Возраст'), td(input([name(age)]))]),
                    tr([th('Пол'), td(input([name(gender)]))]),
                    tr([th('Знание иностранного языка'), td(input([name(language)]))]),
                    tr([th('Умение работать на ПК'), td(input([name(computer)]))]),
                    tr([th('Опыт'), td(input([name(experience)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Добавить'])))
                ])
            ]
        )]
    )
.

%Добавление требования
add_requirements(Request):-
    http_parameters(
        Request,
        [
            education(Education, []),
            age(Age, []),
            gender(Gender, []),
            language(Language, []),
            computer(Computer, []),
            experience(Experience, [])
        ]
    ),
    atom_number(Age, AgeNum),
    atom_number(Experience, ExperienceNum),
    assertz(requirements(Education, AgeNum, Gender, Language, Computer, ExperienceNum)),
    http_redirect(moved, '/', Request).


%Страница с удалением вакансии
delete_requirements_p(_Request):-
    reply_html_page(
        title('Удаление требование'),
        [form(
            [action=location_by_id(delete_requirements), method(post)],
            [
                h3('Удаление требования:'),
                table([
                    tr([th('Образование'), td(input([name(education)]))]),
                    tr([th('Возраст'), td(input([name(age)]))]),
                    tr([th('Пол'), td(input([name(gender)]))]),
                    tr([th('Знание иностранного языка'), td(input([name(language)]))]),
                    tr([th('Умение работать на ПК'), td(input([name(computer)]))]),
                    tr([th('Опыт'), td(input([name(experience)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Удалить'])))
                ])
            ]
        )]
    ).


%Удаление требования
delete_requirements(Request):-
    http_parameters(
        Request,
        [
            education(Education, []),
            age(Age, []),
            gender(Gender, []),
            language(Language, []),
            computer(Computer, []),
            experience(Experience, [])
          ]
    ),
    atom_number(Age, AgeNum),
    atom_number(Experience, ExperienceNum),
    retract(requirements(Education, AgeNum,  Gender, Language, Computer, ExperienceNum)),
    http_redirect(moved, '/', Request).




generate_rows1([], []).
generate_rows1([Company|Companys], [tr([td(Company)])|Rows_]):-    generate_rows1(Companys,  Rows_).



%Реализовать следующие типы запросов:
%1. Найти должность, для которой существует максимальное число соискателей;

task_1(Position) :-
    findall(Count-Position,
            (job_vacancy(_, Position, _, _, Seeker),
             length(Seeker, Count)),
            Counts),
    max_member(MaxCount-_MaxPosition, Counts),
    member(MaxCount-Position, Counts),
    !.

task_1_page(_Request):-
    task_1(Position),
    reply_html_page(
        title('Должность, для которой существует максимальное число соискателей'),
        [h3('Должность, для которой существует максимальное число соискателей:'), p(Position),
         form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]
    ).



%2. Найти все должности для мужчин, с высшим образованием и свободно владеющих иностранным языком;
task_2(Vacancies) :-
    findall(Vacancy, job_vacancy(_, Vacancy, _, ['Высшее', _, 'Мужской', 'Да', _, _], _), Vacancies).
task_2(_).


task_2_page(_Request):-
    task_2(Vacancys),
    generate_rows1(Vacancys, Rows_),
    ins(Rows_, tr(
                  [
                    th('Вакансии')
                  ]
              ), Rows_with_Headers_),
    reply_html_page(
        title('Должности для мужчин, с высшим образованием и свободно владеющих иностранным языком'),
        [h3('Должности для мужчин, с высшим образованием и свободно владеющих иностранным языком:'),
        table(
                [border(2)],
                Rows_with_Headers_
            ),
        form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]
    ).



%3. Найти все предприятия, предлагающие доход выше указанного уровня;
task_3(S, Companies) :-
    findall(Company, (job_vacancy(Company, _, Salary, _, _),
    Salary > S), Companies).
task_3(_, _).

task_3_page(_Request):-
    reply_html_page(
        title('Предприятия, предлагающие доход выше указанного уровня'),
        [form(
            [action=location_by_id(task_3_page_S), method(post)],
            [
                table([
                    tr([th('Введите доход:'), td(input([name(sal), type(number)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Искать'])))
                ] )
            ]
        )]
    ).

task_3_page_S(Request):-
    http_parameters(
        Request,
        [sal(S, [])]
    ),
    % Преобразование S в число
    atom_number(S, SNum),
    task_3(SNum, Companies),
    generate_rows1(Companies, Rows_),
    ins(Rows_, tr(
                  [
                    th('Компании')
                  ]
              ), Rows_with_Headers_),
    reply_html_page(
        title('Предприятия, предлагающие доход выше ~w' - S),
        [h3('Предприятия, предлагающие доход выше ~w :' - S),
        table(
                [border(2)],
                Rows_with_Headers_
            ),
        form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]
    ).




%4. Найти всех соискателей, умеющих работать на ПК, и имеющих стаж работы более 5 лет;

task_4(FullNames) :-
    findall(FullName, (job_seeker(LastName, FirstName, [_, _, _, _, 'Да', Experience]),
    Experience >= 5,
    atomic_list_concat([LastName, ' ', FirstName], FullName)), FullNames).
task_4(_).


task_4_page(_Request):-
    task_4(FullNames),
    generate_rows1(FullNames, Rows_),
    ins(Rows_, tr(
                  [
                    th('Соискатели')
                  ]
              ), Rows_with_Headers_),
    reply_html_page(
        title('Соискатели, умеющие работать на ПК, и имеющие стаж работы более 5 лет'),
        [h3('Соискатели, умеющие работать на ПК, и имеющие стаж работы более 5 лет:'),
        table(
                [border(2)],
                Rows_with_Headers_
            ),
        form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]
    ).


%5. Подсчитать число предприятий, у которых есть заданная вакансия.

task_5(Vacancy, Count) :-
    findall(Company, job_vacancy(Company, Vacancy, _, _, _), Companies),
    length(Companies, Count).


task_5_page(_Request):-
    reply_html_page(
        title('Число предприятий, у которых есть заданная вакансия'),
        [form(
            [action=location_by_id(task_5_page_V), method(post)],
            [
                table([
                    tr([th('Введите вакансию:'), td(input([name(vacancy)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Искать'])))
                ] )
            ]
        )]
    ).

task_5_page_V(Request):-
    http_parameters(
        Request,
        [vacancy(V, [])]
    ),
    task_5(V, Count),
    reply_html_page(
        title('Число предприятий, у которых есть вакансия: ~w' - V),
        [h3('Число предприятий, у которых есть вакансия ~w:' - V), p(Count),
         form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]    ).



