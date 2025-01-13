:-use_module(library(pce)).

gui:-
    new(D, dialog('Лабораторная работа 1. Зиновьева Полина. 6  вариант')),
    send(D, append, new(T1, text_item('Введите список 1'))),
    send(D, append, new(T2, text_item('Введите список 2'))),

    send(D, append, button('Сделать новый список', message(@prolog, show_result, T1?selection, T2?selection))),

    send(D, append, new(_, button('Закрыть', message(D, destroy)))),
    %отобразить окно
    send(D, open).


show_result(Text1, Text2):-
    calc(Text1, Text2, ResultList),
    show_result_dialog(ResultList).

calc(Text1, Text2, ResultList) :-
    atom_codes(Text1, Codes1),
    read_from_codes(Codes1, L1),
    atom_codes(Text2, Codes2),
    read_from_codes(Codes2, L2),

    combine_lists(L1, L2, ResultList).



combine_lists([], _, []).
combine_lists(_, [], []).
combine_lists([H1|T1], [H2|T2], [H1,H2|Result]) :- combine_lists(T1, T2, Result).




show_result_dialog(ResultList):-
    new(D, dialog('Результат')),
    send(D, append, label(lab_cap,'Список, в котором нечетные (по номеру) элементы из первого cписка, а четные - из второго: ')),
    new(Text, text),
    % Соединяем элементы списка в строку с запятыми и пробелами
    atomic_list_concat(ResultList, ',', ResultString),
    % Добавляем квадратные скобки
    atomic_list_concat(['[', ResultString, ']'], ResultWithBrackets),
    % Добавляем строку в компонент text
    send(Text, append, ResultWithBrackets),
    send(D, append, Text),
    send(D, open).



%юнит-тестирование
-use_module(plunit).
:-begin_tests(read).

    %списки с одинаковыми размерностями
    test(test_1) :- combine_lists([1, 2, 3], [4, 5, 6], Result), assertion(Result == [1, 4, 2, 5, 3, 6]), !.

    %списки с разными размерностями
    test(test_2) :- combine_lists([1, 2], [4, 5, 6], Result), assertion(Result == [1, 4, 2, 5]), !.

    %списки с разными размерностями
    test(test_3) :- combine_lists([1, 2, 3], [4, 5], Result), assertion(Result == [1, 4, 2, 5]), !.

    %пустые списки
    test(test_4) :- combine_lists([], [], Result), assertion(Result == []), !.

    %пустые списки разной длины
    test(test_5) :- combine_lists([], [1, 2, 3], Result), assertion(Result == []), !.

    test(test_6) :- once(combine_lists([1, 2, 3], [], Result)), assertion(Result == []).

    %параметризованный тест для 1 значения
    test(parametrized_1, [true(X==[1,4,2,5,3,6])]):- once(combine_lists([1,2,3],[4,5,6], X)).


:-end_tests(read).

