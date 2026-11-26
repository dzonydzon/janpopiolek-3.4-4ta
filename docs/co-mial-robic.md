# Specyfikacja minutnika

Opis odtworzony po fakcie na podstawie aplikacji w repozytorium. Minutnik jest przeznaczony dla jednej osoby, która chce naprzemiennie pracować i odpoczywać.

## Co robi

1. Program zaczyna z ustawionym czasem pracy 25 minut i przerwy 5 minut; oba czasy można zmienić w zakresie od 1 do 180 minut.
2. Program pokazuje aktualną fazę, pozostały czas w formacie minuty:sekundy oraz liczbę ukończonych cykli.
3. Program pozwala rozpocząć, wstrzymać i wznowić odliczanie osobnymi przyciskami.
4. Po zakończeniu pracy program automatycznie rozpoczyna przerwę, a po zakończeniu przerwy — kolejną fazę pracy.
5. Program zwiększa licznik ukończonych cykli po zakończeniu fazy pracy.
6. Program pozwala zresetować minutnik do fazy pracy z aktualnie ustawionym czasem i wyzerować licznik cykli.

## Czego nie robi

- Nie zapisuje historii ukończonych cykli między uruchomieniami.
- Nie odtwarza dźwięku po zakończeniu fazy.

## Po czym poznam

1. Kiedy uruchomię program, to zobaczę fazę „PRACA”, czas pracy 25 minut i przerwy 5 minut, a oba pola pozwolą ustawić wartości od 1 do 180 minut.
2. Kiedy ustawię czas pracy na jedną minutę i kliknę „Start”, to rozpocznie się odliczanie w fazie „PRACA”, a wyświetlany czas będzie malał.
3. Kiedy podczas odliczania kliknę „Pauza”, to czas się zatrzyma; po kliknięciu „Wznów” odliczanie będzie kontynuowane od zatrzymanej wartości.
4. Kiedy upłynie ustawiony czas pracy, to minutnik sam przełączy się na fazę „PRZERWA”, rozpocznie odliczanie przerwy i zwiększy licznik cykli o jeden.
5. Kiedy w trakcie przerwy kliknę „Resetuj”, to minutnik zatrzyma odliczanie, wróci do fazy „PRACA” z ustawionym czasem pracy i wyzeruje licznik cykli.

## Do ustalenia

- Czy po zakończeniu fazy minutnik powinien odtwarzać dźwięk lub pokazywać inne powiadomienie?
- Czy historia ukończonych cykli powinna być dostępna po zamknięciu i ponownym uruchomieniu programu?
- Czy zmiana czasu pracy lub przerwy podczas odliczania powinna zmieniać bieżącą fazę, czy dopiero następne jej wystąpienie?
- Czy wyświetlany czas ma zawsze mieć dwie cyfry minut, np. „09:59”, czy zapis „9:59” jest wystarczający?
