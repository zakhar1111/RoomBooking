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
