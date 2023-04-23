# BuggyCarRating Test Approach Document and Test Automation project solution.

# Description
This project contain a test approach highlighting the 5 main functionalities, the test cases and the bug report for the website.
The technology used is Appium framewrok for testing the website using a mobile device and a web browser.
Due to time constraints the testing was limited to Android Pixel 3 Version 11 on Chrome browser version 112.
Challenges that were faced in this project was the setup and finding the elements due to the different mobile displays. At  most places to find the element the usage of XPATH is used. However, there is a future scope for improvement to the automation solution. The project makes use of the dependency Injection framework Autofac and uses the Page Object Model design pattern. 
Apart from the automation, the test approach is mentioned in a excel sheet which also contains the bug reports. The file name is a called Test approach

# Run the Project
You will need a Pixel 3 Android version 11 phone with a Chrome browser. The Chrome browser version of you laptop/Machine should be the same as the one on you Pixel 3. 

appiumOptions.AddAdditionalCapability("chromedriverExecutable", "path to chrome driver");
appiumOptions.AddAdditionalCapability("chromedriverExecutableDir", "path to chrome driver directory");
In your AutoFacConfig.cs file please mention you chromedriver path. just search for you chromedriver on you machine and copy paste the path in the specified capabilities.

Once you download the solution, Visual studio or Rider should automatically download the packages. If not get the latest Appium driver and selenium driver versions.





