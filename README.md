# TruckRouteAPI

Build an API for truck route. The application receives a three-letter code for a North American Country and returns a list of 
all countries a driver must travel through to go from the United State of America to the destination.

## Assumption
We assume that all routes have the same weight and we want to find the shortest route from USA to the destination.

## Map
Here is simplified map of North America: 

- CAN – Canada borders the United States
- USA – The United States borders Canada and Mexico
- MEX – Mexico borders the United States, Guatemala, and Belize
- BLZ – Belize borders Mexico and Guatemala
- GTM – Guatemala borders Mexico, Belize, El Salvador, and Honduras
- SLV – El Salvador borders Guatemala and Honduras
- HND – Honduras borders Guatemala, El Salvador, and Nicaragua
- NIC – Nicaragua borders Honduras and Costa Rica
- CRI – Costa Rica borders Nicaragua and Panama
- PAN – Panama borders Costa Rica

## Technologies
- C#,.NET Core 3.1 for building the web API
- Azure for deployment
- Docker

## Usage
URL: truckrouteapi.azurewebsites.net

To get a route from USA to destination we need to add three-letter destination CountryCode at the end of URL
For Example:
- truckrouteapi.azurewebsites.net/PAN
should return ["USA", "MEX", "GTM", "HND", "NIC", "CRI", "PAN"] as a part of response.

- truckrouteapi.azurewebsites.net/BLZ
should return ["USA", "MEX", "BLZ"] as a part of response
