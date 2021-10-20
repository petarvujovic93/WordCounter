# WordCounter

Word counter is project that count words from a diferent sourcies. This project contains 2 applications, REST Api and Web application. 
User can choose between 3 sources: 
  - counting words from inputed text, 
  - counting words from uploaded .txt file
  - counting words from database
  
I also uploaded backup file of database that can be used for test in case when user choose option to count words from database.

# Configuration

Web API - It's important to configure database connection string. Connection string name that API is using is 'WordCounter'.
Web UI - Url for WordCounterAPI need to be configured so you may need to configure 'ApiUrl' key in configuration file.
