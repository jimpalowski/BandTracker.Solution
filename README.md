### _BandTracker#_
### Version 1.0
#### By: Rio Atmadja
#### Date: 11 May 2018

##### Description
_This web applications allows users to create a band tracker_

##### Setup/Installation Requirements
* .NET
* C#
* MySql
* PhpMyadmin
* MAMP

##### Known Bugs
_So far there are no bugs_

#### Support and contact details
_If you run into a problem, contact us at abc@epicodus.com_

#### Specs
This project have the following classes
1. Concert Venue
  - Id
  - Name
  - Location
  - Stars
  - Hours
  - Phone

2. Bands
  - Id
  - Name
  - Songs

_specs for users_
1. Create a band
2. View a single concert venue, list out all of the bands that have played at that venue and allow them to add a band to that venue.
3. When a user is viewing a single band, list out all of the venues that have hosted that band and allow them to add Venue to that band.


#### SQL Commands
1. Create Bands table
  * CREATE TABLE `band_tracker`.`bands` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) NOT NULL , `songs` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
2. Create Venue table
  * CREATE TABLE `band_tracker`.`venue` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) NOT NULL , `locations` VARCHAR(255) NOT NULL , `stars` INT NOT NULL , `hours` VARCHAR(255) NOT NULL , `phone` VARCHAR(255) NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
3. Create Join table
 * CREATE TABLE `band_tracker`.`bands_venues` ( `id` INT NOT NULL AUTO_INCREMENT , `band_id` INT NOT NULL , `venue_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

 
### License
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* Copyright (c) 2018 _rio atmadja@epicodus_
####
