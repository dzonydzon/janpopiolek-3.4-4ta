# Dziennik weryfikacji

## 2026-11-19 — budowa 2 przyjęta bez sprawdzenia

- **Sprawdzone:** Wcześniej przyjąłem bez osobnego wpisu, że specyfikacja minutnika opisuje całość jego działania i że aplikacja buduje się oraz uruchamia.
- **Wynik:** Po sprawdzeniu źródeł minutnika w osobnym repozytorium znaleziono `HistoryList.ItemsSource = _history.ToArray()` bez deklaracji kontrolki `HistoryList` w pliku `MainWindow.axaml.cs`. To oznacza, że przyjęta wcześniej obsługa listy nie była poprawnie potwierdzona kompilacją.
- **Nie wiadomo:** Czy minuta aplikacja została później poprawiona i czy aktualne repozytorium źródłowe zawiera pełną historię rozwoju; w tym notatniku sprawdzenie dotyczyło tylko dostępnych informacji i plików.

## 2026-11-19 — weryfikacja notatnika 3.4

- **Sprawdzone: buduje się.** Sprawdziłem, czy dokumenty i projekt notatnika znajdują się w Gitowym repozytorium oraz czy wymagane zmiany mają poprawny format Markdown.
- **Wynik:** Repozytorium nie jest projektem aplikacji i nie ma celu `dotnet build`. Dla wymienionego osobno projektu minutnika próba `dotnet build okno.csproj --no-restore` zakończyła się jednym błędem: `CS0103`, brak nazwy `HistoryList` w `MainWindow.axaml.cs`.
- **Nie wiadomo:** Czy błąd pozostaje aktualny w najnowszym kodzie źródłowym, ponieważ sprawdzana wersja nie jest kopią wskazanego repozytorium notatnika.

- **Sprawdzone: uruchamia się.** Sprawdziłem stan repozytorium notatnika i zawartość dostępnej specyfikacji.
- **Wynik:** Nie uruchomiono aplikacji z tego repozytorium, ponieważ nie zawiera ono kodu programu ani pliku projektu `.csproj`. Uruchomienie tego, co w repozytorium istnieje, dałoby oszukane albo fałszywe „sprawdzenie”, więc nie została zgłoszona jako pozytywna weryfikacja.
- **Nie wiadomo:** Czy osobny projekt minutnika uruchamia się bez innych błędów po skompilowaniu pełnej aktualnej wersji; wymagany byłby test uruchomienia na środowisku Windows z aktualnym kodem.

- **Sprawdzone: zapisuje dokładnie to, co mówi specyfikacja.** Porównałem opis w `docs/co-mial-robic.md` z treścią repozytorium i sprawdziłem, czy specyfikacja zapisuje/nie zapisuje historii między uruchomieniami.
- **Wynik:** W tym repozytorium nie ma kodu zapisu ani pliku danych. Dokument jawnie mówi, że nie zapisuje historii ukończonych cykli między uruchomieniami. Prawidłowe sprawdzenie tej cechy wymagałoby uruchomienia aplikacji i ponownego uruchomienia, ale nie zostało wykonane jako budujący się test, bo źródło nie znajduje się w tym repozytorium.
- **Nie wiadomo:** Czy historia z bieżącego uruchomienia działa mimo braku persystencji oraz czy aplikacja zapisuje inne dane — nie zgaduję i nie uznaję tego za potwierdzone.

## Nazwa z notatnika, której nie umiem wytłumaczyć

- **Nazwa:** `DispatcherTimer`
- **Dokumentacja i data odczytu:** [Klasa DispatcherTimer w Avalonia API](https://api-doc.avaloniaui.net/docs/T_Avalonia_Threading_DispatcherTimer.html), odczytano 2026-11-19.
- **Co robi:** `DispatcherTimer` jest zegarem Avalonia uruchamiającym zdarzenie `Tick` w pulsie interfejsu użytkownika, co pozwala w kodzie aktualizować widoczne kontrolki minutnika.

## 2026-11-26 — poprawka po ocenie

- **Sprawdzone: projekt i kompilacja.** W tym repozytorium dodano aplikację `TimerApp` z plikiem projektu `TimerApp/TimerApp.csproj` i kodem `TimerApp/MainWindow.axaml.cs`. `dotnet build TimerApp/TimerApp.csproj --no-restore` zakończył się kompilacją bez błędów i ostrzeżeń.
- **Wynik:** Budowa działa z repozytorium; nie został użyty projekt spoza pakietu ani brakująca kontrolka `HistoryList`. W projekcie dodano pola ustawień pracy i przerwy, przyciski Start/Pauza/Wznów/Resetuj oraz bieżący licznik cykli.
- **Nie wiadomo:** Nie wykonano jeszcze pełnego testu 1- i 180-minutowego przepływu przez godzinę rzeczywistego czasu; test można skrócić w kodzie odliczania lub przez test jednostkowy logiki.

- **Sprawdzone: uruchamia się.** Uruchomiono `dotnet run --project TimerApp/TimerApp.csproj --no-build`; proces aplikacji desktopowej pozostał aktywny po uruchomieniu i został następnie zatrzymany.
- **Wynik:** Aplikacja uruchamia okno Avalonia i nie zgłasza błędu startowego.
- **Nie wiadomo:** Pełny przebieg pracy/przerwy nie został obserwowany przez czas rzeczywisty; za to kod przełączenia i inkrementacji został bezpośrednio sprawdzony przez przegląd metody `TimerTick`.

- **Sprawdzone: zapis notatek i operacje zapisu.** Wyszukano po `TimerApp` wyrażenia `WriteAllText`, `SaveFileDialog`, `try/catch` oraz połączono wynik z treścią projektu.
- **Wynik:** Minutnik nie implementuje zapisu notatek ani zapisu historii, więc opisane trzy problemy dotyczące dialogu i zapisu pliku nie występują w tej wersji; stan cykli istnieje tylko w pamięci bieżącego uruchomienia.
- **Nie wiadomo:** Nie ma danych zapisanych na dysku, dlatego nie można uczciwie potwierdzić persystencji historii — świadomie nie dodano jej do aplikacji.
