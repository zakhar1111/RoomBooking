# RoomBooking
Rooms Booking service

# Requirements
1. A hotel has many rooms that it can sell to guests. Each room has a unique room number for the hotel, and is on a specific floor.
2. A guest can make a booking for a hotel room. When they book a room, they specify the date they a rechecking in, the date they a rechecking out, the number of adults, and number of children.
3. A guest can book multiple rooms as part of their booking.
4. Each room is a specific type or class, such as Deluxe or Standard. The room type defines the size of the room as well as the features.
5. A room has a range of features, such as air conditioning, TV, or a coffee machine. There's a defined list of features and each room of the same type has the same set of features (for example, all Standard rooms may have a kettle, and all Deluxe rooms may have a kettle and a coffee machine).
6. Each room type has a specific number of beds and type of beds, such as "two single beds" or "one king bed".
7. Each room type has a base price for booking a room for a night 
8. A guest can pay for extra features or privileges for their booking, such as breakfast in the morning, a small extra fee for the ability to get a full refund, or valet parking. These extras may be paid at the time of the booking, or during their stay(such as mini bar usage).
9. The total price for a booking is calculated based on the number of rooms, the number of days, 
the base price for the selected room type , and any extras.
10. The system can indicate whether a guest has paid for their booking or not.
11. The system can tell which rooms are available for booking, which ones are empty and yet to be cleaned, and which ones are cleaned and ready for guests.
12. A guest will need to provide their name, email address, and phone number when making a booking



## Data Design
RoomType-centric
![roombooking](Hotel.png)
1. A hotel has many rooms
   ```
   Hotel → Room
   ```

   - address exists
   - ownership exists
   - room numbering scoped by hotel
     
2. Guest can make booking with dates and guest counts.
   ```
   Booking
    - Guest
    - CheckIn
    - CheckOut
    - Adults
    - Kids
   
   BookingRoom
    - Room
   ```

3. Guest can book multiple rooms.
   ```
   Booking → BookingRoom → Room
   ```

   - support booking multiple rooms in one booking

4. Room has a type/class.
   ```
   Room → RoomType
   RoomType.Size
   ```

   - Single source of truth.

5. Rooms of same type share same features.
   ```
   RoomType → Feature
   ```

   - Standard room type owns features.
   - All Standard rooms inherit them.

6. Room type has specific bed setup.
   ```
   RoomType → RoomTypeBed → BedType
   ```

   - support diffirent configurations
   ```
   Deluxe:
      1 king

   Family:
      2 single

   Suite:
      1 king + 2 single
   ```

7. Room type has base price.
   ```
   RoomType.BasePrice
   ```

   - All Deluxe rooms share price model.

8. Booking extras.
   ```
   Booking → BookingExtra → Extra
   ```

   - Correct separation.
      - Feature = room capability
      - Extra = purchased service

9. Total booking price calculation.
   ```
   Booking.TotalPrice
   BookingRoom.PricePerNight
   BookingExtra
   RoomType.BasePrice
   ```

   - Full pricing model.

10. Paid/unpaid booking.
   ```
   Amount
   PaidAt
   Status
   ```

   - better history

11. Room availability and cleaning.
   ```
   Room → RoomStatus
   ```

12. Guest info.
   ```
   Guest
   Name
   Email
   Phone
   ```
