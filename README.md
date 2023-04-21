# Telepath
Telepath is a distributed application for assistance in the investigation of potentially paranormal phenomena, specifically extrasensory perception. It allows members in a group to submit thoughts at specific times, after which Telepath identifies commonly conceived thoughts as candidates for further study in the context of telepathy.

Members belong to one or more ThinkGroups and submit Thoughts each pertaining to a particular Topic along with a time at which the thought occurred. Reports are generated regularly and on an ad hoc basis to highlight temporal and subjective commonalities between thoughts between Members of a ThinkGroup.

## Project Structure

Telepath follows a general onion architectural style. In the center is Core, upon which all other projects depend. One level up is DataAccess, which serves as an intermediary between the database and the distributed app. On the periphery are the Api, Web, Worker, and Tests projects, all of which depend upon Core and DataAccess.

### Telepath.Core

Core contains the domain classes, that is to say the model of the domain, where the structure and business logic reside. All other projects depend on Core.

### Telepath.DataAccess

DataAccess is where the logic that serves and manipulates database structures as domain objects. DataAccess uses Entity Framework as its object-relational mapper (ORM) and is designed by default to use MSSQL as its underlying data store.

### Telepath.Api

Api is the RESTful Web API service that acts as the primary external interface for access to the data layer. Calls to this service may also result in events and commands being added to the bus.

### Telepath.Worker

The Worker processes events and commands from the bus, directly manipulating the database using DataAccess as well as creating additional events and commands to be queued onto the bus.

### Telepath.Web

Web is a user-friendly interface that allows human interaction with Telepath. As such, it depends weakly on the Api service. Web should not directly read or write to the database. Web, along with the Tests project, are on the outermost periphery of the solution.

### Telepath.Tests

Tests project contains automated unit, integration, and system tests designed to ensure maximal congruence between Telepath's requirements and operation.