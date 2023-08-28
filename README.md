# CI/CD
## Kompletteringsuppgift CI/CD


This console application was created by *Max Guclu*. The project was conducted as part of a *C#* and *Fullstackprojekt med metodik* course in a *Fullstack .NET* program at **Chas Academy**.   

During the project i utilized a Kanban board and and attempted to apply agile methodology and tracked- and version-managed our project with **Trello** and **Git / Github**.   

-  [*Trello link*](https://trello.com/b/RyeLokME/cicd)
-  [*Github link*](https://github.com/akaMaxg/WeatherAPI-React)  

## Installation

The react-client requires [Node.js](https://nodejs.org/) to run. 
After cloning the repo in terminal:

```sh
npm run dev
```

## For the assignment

### Checklists for the assignment
The assignment provided a number of requirements to be filled:

| Checklist | Implemented |
| ------ | ------ |
| Agile work | Trello/Github |
| Test-driven | Wrote unit-tests for API first |
| No DB | No DB was used |
| CI/CD | CI/CD Pipeline was setup through Azure Devops |
| React | Frontend is in React |
| Deployed | React points to deployed |
| Vite | Vite was used | 
| Folder-structure | React is in repo-folder | 
| Live-Demo | Live-demo link uploaded in Github Repo |

### Backlog user-stories

| Backlog | Implemented |
| ------ | ------ |
| Weather data for Stockholm | Start-page provides the weather data |
| Favourite City | Search-field to enter a city that remains during run |
| API-Healthcheck | Online/Offline check |
| Statistics for calls | Counter on start-page tracks API-calls |
| Weather Stockholm  | Weather for Stockholm provided |
| See/save favourite city | Searchfield for a city that persists |


## Pipeline
A pipeline was set up to streamline the CI/CD process.
It is divided over 2 jobs:
- Build API
- Deploy to Azure

The pipeline first builds the minimal API application and runs the tests present in the application. 
Deploy to Azure does not run unless BuildAPI succeeds. It then produces a zip file with necessary configurations which are then deployed to Azure App Services. 


## Contributions & Feedback
If you would like to contribute to this project, please fork the repository and submit a pull request. All contributions, and feedbacks are welcome and appreciated!
