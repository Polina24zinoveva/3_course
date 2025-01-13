my_concat([], L2, L2).
my_concat([H|T1], L2, [H|Result]) :-
    my_concat(T1, L2, Result).

concat_string(S1, S2, Result) :-
    string_chars(S1, Chars1),
    string_chars(S2, Chars2),
    my_concat(Chars1, Chars2, CharsResult),
    string_chars(Result, CharsResult).

test(R1, R2, R3, R4):-
   concat_string("Hello", " world", R1),
   concat_string("Hello", "", R2),
   concat_string("", " world", R3),
   concat_string("", "", R4).
