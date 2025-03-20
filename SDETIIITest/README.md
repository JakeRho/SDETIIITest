This file explains in detail how this solution is structured. 

Hooks: 

The 'Hooks' folder contains one class called 'BaseTest.cs'. The purpose of this file is to contain the setup and teardown logic for the other tests, 
so that the code responsible for creating and later destroying a Chromium browser page does not need repeating. 

Utilities: 

The 'Utilities' folder contains a class called 'HelperMethods.cs'. This file contains custom methods which are designed to simplify/abstract away more 
complex logic, which facilitates smooth running of several test steps. 

AutomationTasks.cs: 

This is the file containing the bulk of the code for this assignment. There are 3 tests within corresponding to the 3 scenarios described in the task briefing: 
1) AddingPickToBetslip 
2) ValidatingLiveOddsUpdate 
3) SelectTennisandValidate

Here is a thorough overview of how the tests are designed to work. It may help in the event that 1 or more of the tests fail to pass, which has been sporadically observed but 
is usually easy to account for. 

(Test 1) AddingPickToBetslip: 
- The test begins by navigating to the 'Event View' page, as per the instructions.
- It then waits for the necessary selector / set of selectors to become available, before calling the helper method 'GetFirstAvailablePickAsync'. 
- The helper method is there as a safety step to ensure that the test cannot easily be hobbled by a locked market, which is a relatively common occurrence. 
- The inner text (participant/team name) is extracted from the selected element and stored in an 'expected' varaible.
- The selector is then confirmed (clicked) 
- Now the betslip is queried and the pick is stored in an 'actual' variable. 
- The pick is now highlighted in bold green, as per the instructions. 
- Finally, three asserts check that: A) There was a valid pick, B) The highlighting has worked, C) The betslip contains the same pick as was selected earlier. 

(Test 2) ValidateLiveOdds:
- The test beging by navigating to the 'Table Tennis' tab, as per the suggested approach. 
- The first available pick is located and stored in a variable 'oddsElement'. 
- The inner text (odds) are extracted. 
- There is an Assertion in the middle of the test which allows up to 60 seconds for the odds to change. 
- Once (if) the odds change within 60 seconds, the test passes and the initial and updated odds will be visible in the test explorer console. 
- The test will fail if the odds do not change in the alloted time but when this occurs, it's easy to interpret why from the Chromium browser popup.
- A potential improvement to this test may query the match period to check that the match is completely in play, as opposed to during the interval. 

(Test 3) SelectTennisAndValidate: 
- This test starts by navigating to the 'A-Z Sports' tab, followed by the option for 'Tennis'. 
- There is a built in expectation that the subsequent tennis tab is always in the same place (5th item along). The assumption is based on the number '5' being hard coded in to the tennis URL and therefore assumed to have a robust internal association with the sport. 
- The test is successful if it passes 3 assertions, as per the instructions: A) the tennis tab is 'active', B) the - assumed to be - tennis tab does indeed say 'tennis', C) 'tennis' is present in the URL. 

