**Getting Started**

* This solution uses an In Memory database, as long as you have .Net Core 3.1 installed, set the EinTech.Test.Web as the start up project and click run.
* You will be taken to an empty grid, Click Add Person and the grid will begin to fill, if the application is killed the data in the database will be removed also.
* However as long as the application is running, you can refresh the home screenm disabling cache etc and the persons saved will still load.

Cheers
Andy

**NOTES**

This exercie has been completed using an Onion Type Architecture.
While the service layer is purely an orchastration layer, however this layer could be used to trigger PRE/POST Workflow logic.
The Repository layer could later be used to implement a repository pattern for other entites, but for now I kept it simple with just a person.
The infrastructuve was introducsed for outside dependencies such as the database and could be later adapted to Queues, file systems etc.