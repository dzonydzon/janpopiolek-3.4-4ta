# Rozbierz to

Poniżej rozbieram trzy pozostałe błędy fragmentu z lekcji „Halucynacje i weryfikacja”. Pierwszy błąd — usunięta klasa `SaveFileDialog` — został omówiony w treści lekcji.

## 1. Zegar poza wątkiem interfejsu

- **Na czym polega:** `System.Timers.Timer` uruchamia zdarzenie `Elapsed` poza wątkiem interfejsu. Próba bezpośredniej zmiany `StatusText.Text` z tego zdarzenia może rzucić wyjątek albo nie zaktualizować kontrolki UI.
- **Kształt:** „Coś, co istnieje, użyte źle” — klasa istnieje i działa jako timer, ale została użyta w niewłaściwym kontekście UI.
- **Kiedy się ujawni:** Przy uruchomieniu aplikacji, po upływie czasu pierwszego zdarzenia `Elapsed`; kompilacja może przejść bez błędów.
- **Jak sprawdzić:** Uruchomić kopię z krótkim intervalem, obserwować zdarzenie i sprawdzić dokumentację API timera oraz mechanizm aktualizacji UI. Test musi być wykonany rzeczywiście — samo przejście kompilacji nie wystarczy.
- **Weryfikacja mojego notatnika:** W projekcie `TimerApp` kod jest dostępny w repozytorium. W `TimerApp/MainWindow.axaml.cs` użyto `Avalonia.Threading.DispatcherTimer` z zdarzeniem `Tick`, które działa w wątku interfejsu. Sprawdziłem to przez odczyt metody `TimerTick`, polecenie `dotnet build` i uruchomienie programu `dotnet run --no-build`; błąd `System.Timers.Timer`/`Elapsed` nie występuje.

## 2. Nadpisanie pliku zamiast bezpiecznego zapisu

- **Na czym polega:** `File.WriteAllText(path, NoteBox.Text)` tworzy nowy plik albo zastępuje całkowitą zawartość istniejącego pliku. Wybór istniejącego dokumentu nie chroni jego poprzedniej treści.
- **Kształt:** „Coś, co działa, ale po cichu kasuje dane” — wynik jest poprawny formalnie i działa bez informacji o utracie poprzedniej treści.
- **Kiedy się ujawni:** Dopiero po pierwszym wybraniu już istniejącego pliku albo po kilku kolejnych zapisach, gdy wcześniejsza treść zostanie zastąpiona.
- **Jak sprawdzić:** Utworzyć plik testowy z kilkoma wierszami, zapisać do niego inną treść i porównać zawartość przed i po operacji. Odczytanie treści po zapisie wykrywa utratę danych.
- **Weryfikacja mojego notatnika:** Po dodaniu projektu `TimerApp` w tym repozytorium nie ma implementacji zapisu notatek ani wywołania `File.WriteAllText`. Wykonałem wyszukiwanie po wszystkich plikach `.cs` i `.axaml`; kod przechowuje tylko bieżący stan minutnika. Dlatego błąd nadpisania nie występuje w tej wersji — aplikacja nie ma funkcji zapisu pliku.

## 3. Zdanie o obsłudze błędów, którego nie potwierdza kod

- **Na czym polega:** Komentarz „Obsługa błędów zapisu jest w środku” jest nieprawdziwy. W podanym fragmentem nie ma `try/catch`, sprawdzenia anulowania dialogu ani obsługi wyjątków zapisu.
- **Kształt:** „Zdanie o kodzie, które nie jest prawdą” — kompilator buduje kod poprawnie, ale nie weryfikuje prawdziwości komentarza opisującego dodatkową funkcję.
- **Kiedy się ujawni:** Przy przeglądzie kodu od razu; przy uruchomieniu — np. przy anulowaniu wyboru pliku albo braku uprawnień do zapisu.
- **Jak sprawdzić:** Otworzyć metodę `SaveButton_Click` i sprawdzić obecność bloków obsługi wyjątków oraz ścieżkę anulowania. Następnie zasymulować brak uprawnień lub niepoprawną ścieżkę i obserwować zachowanie aplikacji.
- **Weryfikacja mojego notatnika:** W projekcie `TimerApp` nie ma operacji zapisu ani komentarza twierdzącego o obsłudze błędów zapisu. Przejrzałem `TimerApp/MainWindow.axaml.cs` i pliki projektu, a wyszukiwanie `try/catch`, `WriteAllText` i `SaveFileDialog` nie znalazło tych mechanizmów. Nie występuje więc fałszywy komentarz o obsłudze zapisu, ponieważ aplikacja minutnika nie implementuje zapisu pliku.
