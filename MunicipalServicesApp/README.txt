MUNICIPAL SERVICES APPLICATION FOR SOUTH AFRICA
README AND IMPLEMENTATION REPORT
============================================================

1. PROJECT OVERVIEW
------------------------------------------------------------

The Municipal Services Application is a C# Windows Forms
application developed using the .NET Framework. The application
provides residents with a digital platform for interacting with
municipal services.

The application provides three main functions:

1. Report Issues
2. Local Events and Announcements
3. Service Request Status

The Report Issues functionality allows residents to submit
municipal problems by providing a location, category,
description and optional supporting attachment.

The Local Events and Announcements functionality allows
residents to view and search upcoming municipal events. The
application also analyses previous searches to recommend
relevant events.

The Service Request Status functionality allows residents to
track submitted requests using a unique reference number.
Advanced data structures and algorithms are used to organise,
retrieve, prioritise and relate service requests efficiently.


2. SYSTEM REQUIREMENTS
------------------------------------------------------------

The following software is required:

- Microsoft Windows
- Visual Studio with C# Windows Forms support
- .NET Framework 4.7.2 or compatible version


3. HOW TO COMPILE THE APPLICATION
------------------------------------------------------------

1. Open Visual Studio.

2. Open the MunicipalServicesApp solution.

3. Wait for Visual Studio to load the project completely.

4. Select:

   Build > Rebuild Solution

5. Confirm that the Output window displays a successful build
   with zero failures.

Example:

   Rebuild All: 1 succeeded, 0 failed

6. Resolve any compilation errors before attempting to run
   the application.


4. HOW TO RUN THE APPLICATION
------------------------------------------------------------

1. Open the MunicipalServicesApp solution in Visual Studio.

2. Build the solution.

3. Press F5 or select the Start button.

4. The Municipal Services Main Menu will open.

The user can then select:

- Report an Issue
- Local Events and Announcements
- Service Request Status


5. REPORT ISSUES
------------------------------------------------------------

The Report Issues feature allows a resident to report a
municipal service problem.

To submit a report:

1. Select "Report an Issue" from the Main Menu.

2. Enter the location of the issue.

3. Select an appropriate category.

4. Enter a detailed description.

5. Optionally select Browse to attach an image or document.

6. The progress indicator provides feedback while the report
   is being completed.

7. Select Submit.

The application validates the required information before
accepting the report.

After successful submission, the application generates a
unique reference number, for example:

   MS-0001

The initial status of a newly submitted request is:

   Submitted

The reference number can later be used in the Service Request
Status feature.


6. LOCAL EVENTS AND ANNOUNCEMENTS
------------------------------------------------------------

The Local Events and Announcements feature displays upcoming
community and municipal events.

Users can:

- View upcoming events.
- Search by category.
- Search by date.
- Display all events.
- View recent searches.
- Receive event recommendations.

The recommendation functionality analyses previous searches.
Categories searched more frequently can be used to recommend
related upcoming events.


7. SERVICE REQUEST STATUS
------------------------------------------------------------

The Service Request Status page allows users to monitor
submitted municipal service requests.

Users can:

- View submitted requests.
- Track a request using its reference number.
- View the highest-priority request.
- Find related requests.
- Perform Breadth-First Search (BFS).
- Perform Depth-First Search (DFS).
- View Minimum Spanning Tree relationships.
- View the current status of a request.
- Update request status.
- View request progress using a ProgressBar.

The status progression is:

   Submitted     = 33%
   In Progress   = 66%
   Resolved      = 100%


8. DATA STRUCTURES AND ALGORITHMS
------------------------------------------------------------

The application uses several data structures to improve the
organisation, retrieval and processing of information.


8.1 LIST
------------------------------------------------------------

A List<ReportedIssue> stores submitted service requests.

Role:
The list provides a simple collection containing all reported
issues.

Contribution:
It allows the application to iterate through all submitted
requests when displaying them on the Service Request Status
page.

Example:
When the Service Request Status form loads, the application
iterates through the issue list and displays the reference
number, category, location and status of each request.


8.2 SORTED DICTIONARY
------------------------------------------------------------

A SortedDictionary is used by the Local Events and
Announcements functionality.

Role:
It organises event information according to date.

Contribution:
SortedDictionary automatically maintains its keys in sorted
order. This makes it suitable for displaying upcoming events
chronologically.

Example:
Events scheduled for 27 August, 28 August and 1 September are
displayed according to their dates rather than the order in
which they were added.


8.3 DICTIONARY
------------------------------------------------------------

Dictionaries are used to associate keys with values.

Role:
A dictionary records information such as search categories
and their search frequencies.

Contribution:
Dictionary lookup is efficient because information can be
retrieved directly using a key.

Example:
If the user repeatedly searches for Sports events, the
application can increase the search count associated with the
Sports category. This information contributes to the
recommendation feature.


8.4 HASHSET
------------------------------------------------------------

A HashSet is used to manage unique information.

Role:
It prevents duplicate event categories from being stored.

Contribution:
A HashSet efficiently determines whether an item already
exists and therefore prevents unnecessary duplicates.

Example:
Even if several events belong to the Sports category,
"Sports" only needs to appear once in the category selection
control.


8.5 STACK
------------------------------------------------------------

A Stack is used to manage recent user searches.

Role:
It follows the Last-In, First-Out (LIFO) principle.

Contribution:
The user's most recent search can be accessed before older
searches.

Example:
If the user searches Community followed by Sports, the Sports
search is considered the most recent search.


8.6 QUEUE
------------------------------------------------------------

A Queue is used for event-related information.

Role:
It follows the First-In, First-Out (FIFO) principle.

Contribution:
Events can be processed in the order in which they are placed
into the queue.

Example:
The earliest queued event can be processed before events that
were added later.


8.7 BINARY SEARCH TREE
------------------------------------------------------------

The ServiceRequestBST class implements a Binary Search Tree.

Role:
Service requests are organised according to their unique
reference numbers.

Contribution:
The tree provides structured searching instead of requiring
the application to inspect every request sequentially.

Example:
A request such as MS-0003 can be located by comparing its
reference number with nodes in the tree and selecting the
appropriate branch.


8.8 AVL TREE
------------------------------------------------------------

The AVLTree is a self-balancing Binary Search Tree.

Role:
It stores service requests while maintaining a balanced tree
structure.

Contribution:
After insertion, rotations can be used to prevent the tree
from becoming excessively unbalanced. A balanced structure
helps maintain efficient search performance.

Example:
When several sequential reference numbers such as MS-0001,
MS-0002, MS-0003 and MS-0004 are inserted, the AVL Tree
balances itself rather than allowing the structure to become
a simple linear chain.


8.9 RED-BLACK TREE
------------------------------------------------------------

The RedBlackTree is another self-balancing search tree.

Role:
It provides efficient storage and retrieval of service
requests using reference numbers.

Contribution:
Red-Black Tree rules control the structure of the tree after
insertions. This prevents excessive tree height and supports
efficient searching.

Example:
The Track Request functionality uses the Red-Black Tree to
locate a ReportedIssue from a reference number such as
MS-0001.


8.10 MIN HEAP
------------------------------------------------------------

The MinHeap is used to prioritise municipal service requests.

Role:
Each request is assigned a numerical priority according to
its category.

The current priority ordering is:

1. Public Safety
2. Electricity
3. Water and Sanitation
4. Roads
5. Waste Management
6. Other categories

Contribution:
The request with the smallest numerical priority is maintained
at the root of the heap. This allows the highest-priority
request to be retrieved efficiently.

Example:
If Public Safety, Roads and Electricity requests exist, the
Public Safety request is returned by the Highest Priority
functionality.


8.11 GRAPH
------------------------------------------------------------

ServiceRequestGraph represents service requests as vertices
within a graph.

Role:
The graph models relationships between service requests.

Requests belonging to the same category can be connected by
edges.

Contribution:
This structure allows relationships between requests to be
represented and traversed efficiently.

Example:
If MS-0002 and MS-0003 are both Roads requests, the
application can create an edge between the two requests.
Selecting Related then identifies the connected request.


8.12 BREADTH-FIRST SEARCH
------------------------------------------------------------

Breadth-First Search is implemented for graph traversal.

Role:
BFS explores connected service requests level by level.

The algorithm uses:

   Queue<string>

to manage references waiting to be visited and:

   HashSet<string>

to prevent the same request from being visited repeatedly.

Contribution:
BFS is useful for discovering service requests connected to a
starting request.

Example:

   Starting request: MS-0002

If MS-0003 is connected to MS-0002, the BFS result includes:

   MS-0002
   MS-0003


8.13 DEPTH-FIRST SEARCH
------------------------------------------------------------

Depth-First Search is another graph traversal algorithm.

Role:
DFS explores a branch of connected requests before returning
to explore other branches.

Contribution:
DFS provides an alternative method of exploring relationships
within the service-request graph.

A HashSet is used to prevent requests from being visited more
than once.

Example:

   Starting request: MS-0002

DFS traverses MS-0002 and then explores its connected
requests, such as MS-0003.


8.14 MINIMUM SPANNING TREE
------------------------------------------------------------

A Minimum Spanning Tree is used to identify an optimised set
of relationships between service requests.

Role:
The MST connects service requests while minimising the total
relationship cost and avoiding unnecessary cycles.

Contribution:
It demonstrates how complex relationships between municipal
requests can be represented using an efficient network.

Example:
For four service requests, the resulting spanning tree
normally contains three connections.

A sample result may resemble:

   MS-0002 <-> MS-0003 | Relationship Cost: 4
   MS-0001 <-> MS-0002 | Relationship Cost: 9
   MS-0001 <-> MS-0004 | Relationship Cost: 9

The lower relationship cost between MS-0002 and MS-0003 can
represent a stronger relationship between those requests.


9. STATUS TRACKING AND PROGRESS
------------------------------------------------------------

Every newly submitted service request begins with the status:

   Submitted

The Service Request Status form allows the status to progress
through:

   Submitted
       |
       v
   In Progress
       |
       v
   Resolved

A ProgressBar provides visual feedback:

   Submitted    = 33%
   In Progress  = 66%
   Resolved     = 100%

When a status is updated, the change is reflected in both the
service-request list and the detailed tracking information.


10. VALIDATION AND USER FEEDBACK
------------------------------------------------------------

The application validates user input to prevent incomplete or
invalid operations.

Examples include:

- Location is required when reporting an issue.
- Category is required.
- Description is required.
- A reference number is required before tracking a request.
- Invalid reference numbers display an informative message.
- Status updates display confirmation messages.
- Empty collections are handled without causing the
  application to crash.

MessageBox controls are used to provide clear warnings,
information and success messages.


11. NAVIGATION
------------------------------------------------------------

The Main Menu provides access to all three major features.

Each feature provides a Back to Main Menu option so that the
user can return to the main application interface.

This provides consistent navigation throughout the
application.


12. TESTING
------------------------------------------------------------

The application was functionally tested before completion.

Testing included:

- Main Menu navigation
- Issue submission
- Input validation
- Unique reference-number generation
- File attachment
- Progress indicators
- Local event display
- Event searching
- Search history
- Event recommendations
- Service-request tracking
- BST searching
- AVL Tree searching
- Red-Black Tree searching
- MinHeap priority retrieval
- Related-request graph functionality
- Breadth-First Search
- Depth-First Search
- Minimum Spanning Tree generation
- Status updates
- Service-request ProgressBar
- Form navigation
- Final application rebuild

The final Visual Studio rebuild completed successfully with
zero build failures.


13. CONCLUSION
------------------------------------------------------------

The Municipal Services Application provides an integrated
Windows Forms solution for citizen engagement with municipal
services.

The completed application combines issue reporting, local
event discovery and service-request tracking. Appropriate
data structures and algorithms are used according to the
requirements of each feature.

Basic collections support general information management,
while advanced structures including Binary Search Trees,
AVL Trees, Red-Black Trees, heaps and graphs support the
organisation and retrieval of service requests. BFS and DFS
provide graph traversal, while the Minimum Spanning Tree
demonstrates optimised relationships between requests.

The final application compiles and runs successfully and
provides residents with a functional interface for interacting
with municipal services.