# RoomBooking Use Cases

## Scope and source

These use cases describe the expected behavior based on requirements 1–12 in
[README.md](README.md#requirements). They describe requirements, not a claim that
the current code implements each flow.

## Actors

| Actor | Responsibility |
| --- | --- |
| Guest | Select rooms, provide booking details, and purchase extras. |
| Hotel staff | Maintain room information, assist with bookings, record payments, and inspect room status. |
| Housekeeping staff | Update room cleaning status. |

Staff roles are inferred to make the operational flows explicit. Authentication,
permissions, and a payment provider are not defined by the requirements.

## UC-01: Configure room types

**Primary actor:** Hotel staff  
**Requirements:** 4, 5, 6, 7  
**Goal:** Define the shared characteristics and nightly base price of a room type.

**Preconditions:** The hotel is available in the system.

**Main flow:**

1. Staff create or select a room type, such as Standard or Deluxe.
2. Staff specify the room size.
3. Staff select features from the defined feature list, such as air conditioning,
   a TV, or a coffee machine.
4. Staff specify each bed type and its quantity, such as one king bed or two
   single beds.
5. Staff set the base price per night.
6. The system saves the room type and applies its characteristics to all rooms
   assigned to that type.

**Alternative flows:**

- A room type may have multiple bed types, such as one king bed and two single beds.
- A feature needed for a room type is missing from the defined list. How staff
  maintain that list remains to be specified.

**Postconditions:** Rooms of the same type share size, features, bed configuration,
and base nightly pricing.

## UC-02: Register a hotel room

**Primary actor:** Hotel staff  
**Requirements:** 1, 4  
**Goal:** Add a physical room to a hotel's inventory.

**Preconditions:** The hotel and the required room type exist.

**Main flow:**

1. Staff select the hotel.
2. Staff enter the room number and floor.
3. Staff assign a room type.
4. The system checks that the room number is unique within that hotel.
5. The system saves the room.

**Alternative flow:** If the room number already exists in the selected hotel,
the system rejects the duplicate and asks for a different number. The same number
may exist in another hotel.

**Postconditions:** The hotel has a room with a unique number, a floor, and an
assigned room type.

## UC-03: Find available rooms

**Primary actor:** Guest or hotel staff  
**Requirements:** 2, 4, 5, 6, 7, 11  
**Goal:** Identify rooms that can be booked for a requested stay.

**Preconditions:** The hotel has rooms with configured room types.

**Main flow:**

1. The actor selects a hotel and supplies check-in and check-out dates.
2. The actor supplies the number of adults and children.
3. The system determines which rooms are available for the requested period.
4. The system presents available rooms with their room type, size, features,
   bed configuration, and base nightly price.
5. The actor selects one or more rooms to continue to booking.

**Alternative flows:**

- No rooms are available. The system reports this so the actor can change the
  requested dates or selection.
- Invalid stay dates are supplied. The system requests corrected dates before
  calculating availability; exact date validation rules require confirmation.

**Postconditions:** The actor has an availability result. Searching alone does
not create a booking.

## UC-04: Create a booking for one or more rooms

**Primary actor:** Guest  
**Supporting actor:** Hotel staff, when assisting a guest  
**Requirements:** 2, 3, 9, 12  
**Goal:** Reserve the selected rooms for a stay under one booking.

**Preconditions:** The selected rooms exist and are available for the requested
period.

**Main flow:**

1. The guest selects one or more rooms.
2. The guest provides check-in and check-out dates and the numbers of adults and
   children for the booking.
3. The guest provides their name, email address, and phone number.
4. The guest optionally selects paid extras as described in UC-05.
5. The system checks that required booking details are present and that all
   selected rooms are still available.
6. The system calculates the total as described in UC-06.
7. The guest confirms the booking details and total.
8. The system saves one booking containing the guest details, stay dates,
   guest counts, selected rooms, extras, and calculated total.

**Alternative flows:**

- Required guest details are missing. The system requests the missing information
  before completing the booking.
- A selected room is no longer available. The system asks the guest to revise
  the room selection before completing the booking.
- The guest selects multiple rooms. The system includes all selected rooms in
  the same booking and its total.

**Postconditions:** One booking contains all selected rooms and the required guest
information. Payment status is available through UC-07.

## UC-05: Add paid extras to a booking

**Primary actor:** Guest  
**Supporting actor:** Hotel staff  
**Requirements:** 8, 9  
**Goal:** Include additional purchased services or privileges in a booking.

**Preconditions:** A booking is being created or already exists; the relevant
extra and its charge are available.

**Main flow:**

1. The guest requests an extra, such as breakfast, valet parking, or the
   full-refund privilege.
2. The system or assisting staff identifies the applicable charge.
3. The system associates the extra and its charge with the booking.
4. The system recalculates the booking total.
5. Payment is recorded when the extra is paid, either at booking time or during
   the stay.

**Alternative flow:** An extra is consumed during the stay, such as minibar usage.
Staff record the charge against the existing booking and the system updates the
total and payment status.

**Postconditions:** The extra is included in the booking price. Included room
features, such as a TV, remain distinct from purchased extras.

## UC-06: Calculate the booking total

**Primary actor:** Guest or hotel staff  
**Requirements:** 7, 8, 9  
**Goal:** Determine the price of all booked rooms and extras.

**Preconditions:** The booking has stay dates, selected rooms with nightly prices,
and any selected extra charges.

**Main flow:**

1. The system determines the chargeable duration from the stay dates.
2. For each selected room, the system multiplies the nightly price based on its
   room type by the chargeable duration.
3. The system adds the room subtotals.
4. The system adds the charges for all booking extras.
5. The system presents the resulting booking total.

**Proposed calculation:**

```text
Room subtotal = sum(each selected room's nightly price × number of nights)
Booking total = room subtotal + sum(applicable extra charges)
```

**Example:** Two rooms priced at 100 and 150 per night for three nights, plus a
30 extra charge, produce a total of `(100 + 150) × 3 + 30 = 780` currency units.

**Alternative flow:** Adding an extra during the stay triggers recalculation.

**Postconditions:** The booking has a total that includes every selected room and
recorded extra. The night-counting convention is an assumption listed below.

## UC-07: Record payment and inspect payment status

**Primary actor:** Hotel staff  
**Requirements:** 8, 10  
**Goal:** Know whether a booking has been paid for.

**Preconditions:** The booking exists and has a calculated total.

**Main flow:**

1. Staff open the booking and inspect its total and payment status.
2. When payment is received, staff or a future payment integration record it
   against the booking.
3. The system updates the booking's paid or unpaid indication based on the
   recorded payment information.
4. Staff view the updated payment status.

**Alternative flows:**

- No payment has been recorded. The system indicates that the booking is unpaid.
- A new extra increases the total after payment. The system reassesses whether
  the booking is fully paid under the agreed payment rules.

**Postconditions:** The system can indicate whether the booking is paid. Payment
collection, partial payments, and refunds require further rules.

## UC-08: Inspect and update room readiness

**Primary actor:** Hotel staff or housekeeping staff  
**Requirements:** 11  
**Goal:** Distinguish rooms that are empty and awaiting cleaning from rooms that
are cleaned and ready for guests.

**Preconditions:** The room exists in the hotel's inventory.

**Main flow:**

1. Staff view the room's current status.
2. When a room becomes empty and needs cleaning, staff record that condition.
3. Housekeeping clean the room.
4. Housekeeping mark the room as cleaned and ready for guests.
5. The system displays the updated readiness to hotel staff.

**Alternative flow:** Cleaning is incomplete. The room remains marked as awaiting
cleaning.

**Postconditions:** Staff can identify empty rooms awaiting cleaning and rooms
ready for guests. Date-based booking availability is assessed in UC-03; how
cleaning status affects bookability requires confirmation.

## Requirement coverage

| README requirement | Use cases |
| --- | --- |
| 1. Hotel rooms, unique numbers, and floors | UC-02 |
| 2. Stay dates and adult/child counts | UC-03, UC-04 |
| 3. Multiple rooms in one booking | UC-04 |
| 4. Room type and size | UC-01, UC-02, UC-03 |
| 5. Shared room-type features | UC-01, UC-03 |
| 6. Bed types and quantities | UC-01, UC-03 |
| 7. Base price per night | UC-01, UC-03, UC-06 |
| 8. Paid extras at booking or during the stay | UC-05, UC-06, UC-07 |
| 9. Total booking price | UC-04, UC-05, UC-06 |
| 10. Paid/unpaid indication | UC-07 |
| 11. Availability and cleaning readiness | UC-03, UC-08 |
| 12. Guest name, email, and phone | UC-04 |

## Assumptions and rules to clarify

- **Stay duration:** The proposed calculation charges per night, with check-out
  excluded. Requirement 9 mentions days while requirement 7 specifies a nightly
  price; confirm the intended convention and same-day stay behavior.
- **Booking conflicts:** Availability checking assumes a room cannot be booked
  for overlapping stays. Confirm date boundaries, room holds, and which booking
  statuses block availability.
- **Guest counts:** The requirements capture adult and child counts for the
  booking. Minimum counts, age definitions, room capacity, and allocation of
  guests across rooms are unspecified.
- **Extras:** Define whether each extra is charged per booking, room, person,
  night, or consumed unit, and when each extra may be purchased.
- **Payment:** Define how payment completion is determined, including partial
  payments and additional charges incurred after an earlier payment.
- **Prices:** Currency, taxes, discounts, rounding, and the effect of future
  room-type price changes on existing bookings are unspecified.
- **Room operations:** Define the initial room status, permitted status changes,
  and whether an unclean room can be booked for a future stay.
- **Refunds and cancellations:** The full-refund privilege is a purchasable extra
  in scope. Eligibility rules and cancellation/refund execution are not defined.
- **Hotel selection:** The flows assume a booking selects rooms from one hotel;
  cross-hotel bookings are not specified.
