# Co miał robić minutnik

Opis sporządzony po fakcie na podstawie obecnego zachowania aplikacji.

## Co robi

1. Program pozwala ustawić czas pracy i przerwy w zakresie od 1 do 180 minut.
2. Program pokazuje aktualną fazę oraz odliczany do jej końca czas.
3. Program pozwala rozpocząć, wstrzymać i wznowić odliczanie.
4. Program automatycznie przełącza się między fazą pracy i przerwy po upływie ustawionego czasu.
5. Program zwiększa licznik ukończonych cykli po zakończeniu fazy pracy.
6. Program pozwala zresetować minutnik do fazy pracy i wyzerować licznik cykli.

## Czego nie robi

- Nie zapisuje historii ukończonych cykli między uruchomieniami.
- Nie odtwarza dźwięku po zakończeniu fazy.

## Po czym poznam

1. Kiedy ustawię czas pracy na jedną minutę i kliknę „Start”, to rozpocznie się odliczanie w fazie „PRACA”.
2. Kiedy podczas odliczania kliknę „Pauza”, to odliczanie zatrzyma się, a przycisk zmieni nazwę na „Wznów”.
3. Kiedy kliknę „Wznów”, to odliczanie będzie kontynuowane od zatrzymanej wartości.
4. Kiedy upłynie ustawiony czas pracy, to minutnik sam przełączy się na fazę „PRZERWA”, rozpocznie odliczanie przerwy i zwiększy licznik cykli o jeden.
5. Kiedy w trakcie przerwy kliknę „Resetuj”, to minutnik zatrzyma odliczanie, wróci do fazy „PRACA” z ustawionym czasem pracy i wyzeruje licznik cykli.

## Do ustalenia

- Czy brak dźwięku po zakończeniu fazy jest zamierzony, czy minutnik powinien powiadamiać o jej końcu?
- Czy historia ukończonych cykli powinna być dostępna po zamknięciu i ponownym uruchomieniu programu?
- Czy zmiana czasu pracy lub przerwy podczas pauzy powinna zmieniać również bieżące odliczanie?
