blishe(V1, V2, [V1|Rest]):-member(V2, Rest).
blishe(V1, V2, [_| T]):-blishe(V1, V2, T).


choose([], _).
choose([H|T], Values):- member(H, Values), choose(T, Values), \+ member(H,T).


solve(R):-
    %  Одноклассники(3 человека):
    % - имя
    % - цвет волос
    % - любимый предмет
    R = [people(N1, C1, S1),
         people(N2, C2, S2),
         people(N3, C3, S3)
        ],

    % Миша любит физику и сидит ближе к классной доске, чем рыжий.
    blishe( people(_, rushiy, _), people(misha, _, physics),  R),


    %Блондин Коля сидит ближе к классной доске, чем любитель литературы.
    blishe( people(_, _, literature), people(kolya, blondin, _), R),

    %Тот, кто любит математику, сидит за первой партой.
    S3 = mathematics,

    %Один из них брюнет.
    member(people(_, brunet, _), R),


    choose([N1, N2, N3], [kolya, misha, andrey]),
    choose([C1, C2, C3], [rushiy, blondin, brunet]),
    choose([S1, S2, S3], [physics, literature, mathematics]).

