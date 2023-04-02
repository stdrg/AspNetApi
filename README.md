# WebApi mit .NET 7.0 und ASP.NET

Dieses WebAPI-Projekt wurde mit .NET 7.0 und ASP.NET erstellt und verwendet eine In-Memory-Datenbank, die die Entitäten "Vermittler" und "Adresse" enthält. Beide Entitäten sind bitemporal, was bedeutet, dass sie über zwei verschiedene Zeitachsen verfügen: eine für die Gültigkeitsdauer und eine für die Systemzeit.

## Voraussetzungen

Um dieses Projekt ausführen zu können, benötigen Sie Folgendes:

- .NET 7.0 SDK
- Docker

## Installation

1. Klonen Sie das Repository oder laden Sie die ZIP-Datei herunter und entpacken Sie sie.
2. Wechseln Sie in das Verzeichnis des Projekts.
3. Geben Sie `docker build -t mywebapi .` ein, um das Docker-Image zu erstellen.
4. Geben Sie `docker run -d -p 8080:80 mywebapi` ein, um den Docker-Container zu starten.

Nachdem der Container gestartet wurde, können Sie auf die WebApi über `http://localhost:8080/api` zugreifen.

## Verwendung

Die WebApi bietet einige Endpunkte für den Zugriff auf die Beispieldaten. Sie können beispielsweise `http://localhost:8080/api/` aufrufen, um eine Liste aller Produkte abzurufen. Weitere Endpunkte und deren Verwendung können der Dokumentation entnommen werden.

## Endpunkte:

| Endpunkt                                 | Methode | Beschreibung                                                 |
| ---------------------------------------- | ------- | ------------------------------------------------------------ |
| `/api/Adresse`                           | GET     | Gibt eine Liste aller Adressen zurück.                       |
| `/api/Adresse/{id}`                      | GET     | Gibt die Adresse mit der angegebenen ID zurück.              |
| `/api/Adresse/{vermittlerId}`            | POST    | Fügt eine neue Adresse einem Vermittler hinzu.               |
| `/api/Adresse/{id}`                      | PUT     | Aktualisiert die Adressen mit der angegebenen ID.            |
| `/api/Adresse/{id}`                      | DELETE  | Löscht die Adresse mit der angegebenen ID.                   |
| `/api/Vermittler`                        | GET     | Gibt eine Liste aller Vermittler zurück.                     |
| `/api/Vermittler/{id}`                   | GET     | Gibt einen Vermittler mit der angegebenen ID zurück.         |
| `/api/Vermittler/{vermittlerId}`         | POST    | Fügt einen neuen Vermittler hinzu.                           |
| `/api/Vermittler/{id}`                   | PUT     | Aktualisiert den Vermittler mit der angegebenen ID.          |
| `/api/Vermittler/{id}`                   | DELETE  | Löscht den Vermittler mit der angegebenen ID.                |
| `/api/VermittlerHistorie/{vermittlerId}` | GET     | Gibt eine Liste Historie eines Vermittlers mit der angegebenen ID zurück. |
| `/api//AdressenHistorie/{vermittlerId}`  | GET     | Gibt eine Liste Historie einer Adresse mit der angegebenen ID zurück. |
|                                          |         |                                                              |

