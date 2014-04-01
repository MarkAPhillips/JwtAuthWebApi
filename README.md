JwtAuthWebApi
=============

JWT Authentication for Web API 2 using the JSON Web Token Handler from Microsoft. (http://msdn.microsoft.com/en-us/library/dn205065(v=vs.110).aspx)

The sample Web API is available to be hosted as a console app for ease of use.

Get the solution and restore nuget packages. There are three projects in the solution, with self-explanatory names.

To RUN:
Run or debug the WebApiSelfHost.exe
Through fiddler, make a POST request to http://localhost:90/login, passing in the username and password.

POST /login HTTP/1.1
User-Agent: Fiddler
Host: localhost:90
Content-Type: application/json

{"Username":"admin", "Password":"password"}

Once you receive 200 OK from the web api, inspect the response and copy the access token in the response. Something like this:

AccessToken=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.xxxx....xxxx.MgtSlCzW1jeUalhEP9-AHPcg_WqOS9LcczuW_MJmEDo

Make a subsequent GET request to /books as follows, by adding an Authorization header as follows:

GET /books HTTP/1.1
User-Agent: Fiddler
Host: localhost:90
Content-Type: application/json
Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.xxxx....xxxx.MgtSlCzW1jeUalhEP9-AHPcg_WqOS9LcczuW_MJmEDo

The API returns two book names, after passing through authentication and authorization.