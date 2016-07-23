Getting Up and Running with the Power BI Service
================================================

**Setup Time**: 60 minutes

**Lab Folder**: C:\\Student\\Modules\\01\_IntroToPowerBI\\Lab

**Overview**: This lab covers how to get up and running with Power BI by
creating a new Office 365 tenant with trial subscriptions to Office 365
and Power BI Pro. The act of creating and configuring this new Office
365 tenant will yield an isolated testing and development environment
for working on projects with the Power BI service and using Microsoft’s
latest self-service BI tools such as Power BI Desktop and Microsoft
Excel 2016. One valuable aspect of creating a new and isolated Office
365 tenant is that you will have tenant-level administrative permissions
allowing you to configure the tenant with multiple user accounts for
testing your Power BI projects in isolation from any existing Office 365
tenancy.

### Exercise 1: Create a new Office 365 Trial Tenant

In this exercise, you will create a new Office 365 tenant which allows
you to create up to 25 user accounts with Enterprise E5 trial licenses.
Note that the Enterprise E5 trial license provides the benefits of the
Power BI Pro license. Being able to create multiple Office 365 user
accounts in your Power BI testing environment will be important so that
you can test the effects of sharing Power BI dashboards between users.

1.  Navigate to the following URL:

<https://go.microsoft.com/fwlink/p/?LinkID=698279&culture=en-US&country=US>

1.  Fill out the form with your personal information and click **Next**.

![](media/image1.png){width="4.72in" height="2.9872484689413823in"}

The information you provide here will be used throughout your tenant so
if you do not wish to use your actual company name then provide humorous
and fictitious company name. The name you use for company name will turn
out to be the name of the trial Office 365 tenant that you are creating.

1.  On the next page, you are prompted to provide a user ID, company
    name and password.

Note that the company name you enter on this page will be used to create
the domain name for your new Office 365 trial tenant. For example, if
you were to enter a company name of **CptPowerBiTenant**, it would
result in the creation of a new Office 365 tenant within a domain of
**CptPowerBiTenant.onMicrosoft.com**. The user name you enter will be
used to create the first user account which will be given administrative
rights within the trial tenant. If you enter a user name of **Student**,
then the email address as well as user principal name for this account
will be **Student@CptPowerBiTenant.onMicrosoft.com**.

1.  Enter a user name and a company name for your new Office 365
    trial tenant. For the company name, you may wish to simply use your
    first and/or last name with a number which you can increment each
    time you have to create a new trial account (e.g.
    EricClapton1.onmicrosoft.com).

![](media/image2.png){width="4.716666666666667in"
height="2.5813123359580055in"}

Don’t use your actual company name as that may cause some conflict when
your company decides to create their own official tenant. Throughout the
remainder of this guide you will see a company domain name of
**CptPowerBiTenant** which you should replace with the value specified
for your company name.

1.  Click **Next** to continue to step 3.

2.  Complete the validation form in step 3 by proving you are not
    a robot.

3.  Select the **Text me** option and provide the number of your
    mobile phone.

4.  When you go through this process, a Microsoft service will send you
    a text message that contains an access code.

5.  You retrieve the access code form your mobile device and use it to
    complete the validation process.

![](media/image3.png){width="3.3333333333333335in"
height="1.2153521434820647in"}

1.  Once you have completed the validation process, click the **You’re
    ready to go…** link to navigate to the portal welcome page for your
    new Office 365 trial tenant. Note that you should already be logged
    on using the user account that was created during the sign
    up process.

![](media/image4.png){width="3.4084503499562553in"
height="1.6985389326334208in"}

At this point, you have already created your new Office 365 tenant which
can support creating up to 25 user accounts with Office 365 Enterprise
E5 trial licenses. Note that some Office 365 services within your new
Office 365 tenant such as the Office 365 admin center can be accessed
immediately. Other services within your Office 365 tenant such as
SharePoint Online are not ready immediately and will take some time to
provision.

1.  At this point, you should be located on the portal welcome page of
    Office 365. You will notice that this page shows the progress of the
    Office 365 environment in setting up each of the individual services
    that make up your new Office 365 tenant. Click the **Admin** tile to
    proceed to the Office **365 admin center**.

![](media/image5.png){width="4.352113954505687in"
height="2.901408573928259in"}

In of April 2016, Office 365 introduced a new user interface experience
of the Office 365 admin center which is currently in preview. While it
will be possible for you to fall back on the older UI experience for the
Office 365 Admin center, we assume you will use the new preview edition
so that is what we will show in the screenshots for this lab.

1.  If you are presented with the Office 365 admin center welcome
    dialog, close it by clicking the **X** menu in the upper
    right corner.

![](media/image6.png){width="2.6901410761154856in"
height="1.1258541119860017in"}

1.  Verify that you are able to access the home page of the **Office 365
    admin** **center**.

2.  The following screenshot shows the Office 365 Admin with the
    introduction of the new user interface experience that was
    introduced in April of 2016.

![](media/image7.png){width="4.64461832895888in"
height="2.4647889326334207in"}

1.  Locate the top **Menu** button for the left navigation menu. It’s
    the second button from the top which sites just beneath the Office
    365 App Launcher menu button.

![](media/image8.png){width="0.9295778652668416in"
height="1.2796259842519686in"}

1.  Click the top **Menu** button several times and see how it toggles
    the left navigation between a collapsed and expanded mode.

![](media/image9.png){width="2.306982720909886in"
height="2.4084503499562553in"}

If you are interested in getting more familiar with the **Office 365
admin center**, take a minute to explore the administrative pages behind
the left navigation menu in the Office 365 admin center.

1.  Make sure you can access mail and your Office 365 inbox.

2.  Click on the Office 365 App Launcher menu button in the top-left
    corner of the page.

![](media/image10.png){width="3.9423075240594927in" height="0.4in"}

1.  Click the **Mail** tile button in the App Launcher menu to navigate
    to the Exchange Online inbox for the current user.

![](media/image11.png){width="3.5233573928258966in" height="2.46in"}

1.  If prompted, specify your language and time zone for Outlook.

![](media/image12.emf){width="2.4225349956255466in"
height="1.3168733595800526in"}

1.  You should now see a web page with the Office 365 Outlook web access
    client and a view of the Exchange inbox that is associated with the
    primary user account that was created when you created the Office
    365 tenancy.

![](media/image13.png){width="4.323943569553806in"
height="2.594365704286964in"}

1.  Test email by sending a message to one of your other email
    addresses, Display the form to create a new email clicking the
    **New** button. If the **New** button is not showing, it’s probably
    because the form to create a new email is already showing.

![](media/image14.png){width="4.028169291338583in"
height="1.4071905074365705in"}

1.  At this point, you should see the Outlook form to create new email
    on the right side of the page.

![](media/image15.png){width="4.971830708661417in"
height="1.583517060367454in"}

1.  Fill out the new email form using sample data (see example below) to
    send a test message. Be sure to send the test message to an email
    address that is yours. Click **Send** when it’s ready to go.

![](media/image16.png){width="3.2112674978127735in"
height="3.1870614610673664in"}

1.  Click **Send** to send the email.

2.  Check the email account you sent the email to and verify that you
    received the email.

3.  Reply to the email to verify that you can send an email to your
    new account.

4.  Return to the Outlook Web Client and verify receipt of your reply.

![](media/image17.png){width="5.757344706911636in"
height="3.154928915135608in"}

Having access to mail is valuable when you are working with Power BI.
That's because the Office 365 and the Power BI service use email
messages to send invitations and notification to users is response to
user actions such as creating a new group workspace or sharing a
dashboard.

### Exercise 2: Upload a Workbook with Sample Data to OneDrive for Business

In this exercise, you will upload an Excel workbook file containing
sample data to OneDrive for Business. However, the first step will to
download a copy of the sample Excel workbook to your local hard drive.

1.  Ensure you have downloaded the **Student.zip** file associated with
    this training course and extracted the contents of this zip archive
    into a local direct at **C:\\Student**.

2.  Locate the sample Excel workbook file at the following path.

C:\\Student\\Data\\WingtipSalesData.xlsx

You can also download this file from
<https://github.com/CriticalPathTraining/PBI365/raw/master/Student/Data/WingtipSalesData.xlsx>

1.  Open OneDrive for Business by clicking the **OneDrive** icon in the
    Office 365 App Launcher.

![](media/image18.png){width="2.434041994750656in" height="1.76in"}

1.  If you are prompted by the **Get the most out of SharePoint**
    dialog, click **No Thanks** button to dismiss this dialog.

2.  When you first navigate to your OneDrive for Business site, you will
    be prompted with the following page. Click **Next**.

![](media/image19.emf){width="2.92in" height="1.794970472440945in"}

1.  You should now be at the main landing page for **OneDrive for
    Business** which displays the **Documents** library.

![](media/image20.emf){width="3.1267607174103236in"
height="1.8094083552055993in"}

1.  Click the **Upload** button and go through the steps to upload the
    local copy of **WingtipSalesData.xlsx** to the
    **Documents** library. Once you have completed this step, you should
    be able to verify that the **Documents** library contains
    **WingtipSalesData.xlsx**.

![](media/image21.emf){width="6.431147200349956in"
height="1.7323939195100613in"}

1.  Inside the **Documents** library, locate and click on the
    **WingtipSalesData** link to open the workbook in Excel Online. As
    you can see, the workbook contains a sample set of tabular data that
    will be used in a later exercise.

![](media/image22.png){width="4.24463801399825in"
height="2.4929571303587053in"}

Now you have uploaded an Excel workbook with sample data to a OneDrive
for Business site. In an upcoming exercise, you will use the data inside
this Excel workbook to create a dataset, a report and a dashboard in the
Power BI service.

### Exercise 3: Add a Secondary User Account for Testing Purposes

In this exercise, you will configure your new Office 365 tenant by
creating a secondary user account that you will need later when you
begin experimenting with the Power BI dashboard sharing process.

1.  Return to Office 365 admin center by clicking the **Admin** icon in
    the Office 365 App Launcher.

<!-- -->

1.  Inspect the set of Active Users in the current tenancy.

2.  In the left navigation menu, expand the **Users** node and click
    **Active Users** to navigate to the **Active Users** page.

![](media/image23.png){width="1.2413790463692038in"
height="1.3075470253718284in"}

1.  Once the **Active Users** page is displayed, you should be able to
    verify that the user account you are currently logged on as is the
    only user account that exists in the current tenancy. Remember that
    this account has been set up as a Global Administrator to the tenant
    because it is the account that was used when creating the tenant.

![](media/image24.png){width="5.694617235345582in"
height="1.2183902012248469in"}

1.  Create a new user account.

2.  On the **Active Users** page, click the button **Add a user** button
    to create a new user account

. ![](media/image25.png){width="2.6338035870516188in"
height="1.034041994750656in"}

1.  Fill in the **Create new user account** form with information for a
    new user account. When creating this account, you can use any name
    you would like. These lab instructions will demonstrate this by
    creating a user account for a person named **James Bond** with a
    user name and email of **JamesB@CptPowerBiTenant.onmicrosoft.com**.

![](media/image26.png){width="3.098591426071741in"
height="1.9366196412948382in"}

1.  Expand **Password** section under **Contact Information** section.

2.  Select the option for **Let me create the password**.

3.  Enter a password of **pass@word1** into the textboxes labeled
    **Password** and **Retype** **Password**.

4.  Uncheck the checkbox for the option labeled **Make this user change
    their password when they first sign in**.

![](media/image27.png){width="2.1205063429571305in"
height="1.746479658792651in"}

1.  Expand the roles section. You do not need to change anything in this
    section, although you should note that this new user account will be
    created as a standard user account without any administrator access
    or privileges.

![](media/image28.png){width="1.802817147856518in"
height="1.7646030183727035in"}

Note that the new account has been automatically assigned trial license
for **Office 365 Enterprise E5** plan. That means you do not need to do
anything further to enabled support for Power BI. Having the for
**Office 365 Enterprise E5** license provides the same level access as a
**Power BI Pro** license.

1.  Click the Save button at the bottom of the new user form to create
    the new user account.

![](media/image29.png){width="2.0862062554680665in"
height="0.9297594050743657in"}

1.  When you see the **User was added** message, click **Send email and
    close** to dismiss the **Add new user** task pane.

2.  Verify that the new user account has been created and is displayed
    along with your primary user account.

![](media/image30.png){width="5.54in" height="1.046444663167104in"}

### Exercise 4: Use the Power BI Service to Import a New Dataset

Now, after all that busy work, you are finally ready to begin working
with Power BI. In this exercise you will begin by importing data from an
Excel workbook to create a new Power BI dataset. In the exercise steps
that follow, you will create a report and a dashboard.

1.  In the browser, navigate to the Power BI service by clicking the
    **Power BI** icon in the Office 365 App Launcher. If you are
    prompted to log on, make sure you log on using the same primary
    Office 365 user account that you created earlier when you created
    the Office 365 trial account. In other words, sign on with the
    administrator account and not with the secondary user account you
    created in the previous exercise.

![](media/image31.png){width="1.4495975503062117in" height="1.38in"}

What usually happens when you click the **Power BI** tile in the Office
365 Application Launcher is that you will navigate to the page that
shows the dashboards, reports and datasets in your personal workspace.
However, your personal workspace is initially empty so it doesn’t
contain any dashboards, reports or datasets yet. Therefore, the Power BI
service display a special welcome page that allows you to get started by
linking to or importing data.

1.  At this point, you should be at the Welcome to Power BI page as seen
    in the following screenshot.

![](media/image32.png){width="4.205171697287839in" height="2.48in"}

1.  Import data from an Excel workbook file.

2.  Click in the **Get** button in the **Files** tile under the **Import
    or Connect to Data** section header.

![](media/image33.png){width="6.162891513560805in"
height="2.071428258967629in"}

1.  On the next page you should see several tiles which indicate your
    choices for the location of the file you would like to connect to
    or import. Click on the tile with the caption **OneDrive –
    Business** so you can import data from the Excel workbook you
    uploaded to your OneDrive site in a previous exercise.

![](media/image34.png){width="6.29504593175853in"
height="1.8877548118985128in"}

1.  One the **OneDrive for Business** page, select the workbook named
    **WingtipSalesData.xslx** and then click the **Connect** button on
    the top right-hand side of the page.

![](media/image35.png){width="6.303731408573928in"
height="2.1041666666666665in"}

1.  After clicking the **Connect** button in the previous step, you are
    taken to a page which prompts you to **Choose how to connect to your
    Excel workbook**. Click the **Import** button on the bottom
    left-hand side of the page to import data from the Excel workbook
    into the Power BI service to create a new dataset.

![](media/image36.png){width="6.15994094488189in" height="2.96875in"}

At this point you might make the observation that Microsoft has worked
to streamline the user experience in Power BI when working with data
files that have been uploaded to OneDrive sites. Once you upload your
data files to a OneDrive site, they are very easy to access and
integrate into your Power BI workspaces.

1.  After the import process has completed, the Power BI service will
    display a dashboard that was created during the import of the file
    **WingtipSalesData.xlsx**.

![](media/image37.png){width="4.431034558180228in"
height="1.5549650043744532in"}

1.  Expand the left navigation menu.

2.  Click the top menu button for Power BI directly below the Office 365
    App launcher to expand the left navigation menu.

![](media/image38.png){width="2.6470352143482065in"
height="0.9868055555555556in"}

1.  Once you have expanded the left navigation menu, you should be able
    to see that the import process has created a dashboard named
    **WingtipSalesData.xlsx** and a dataset named **WingtipSalesData**.

![](media/image39.png){width="3.7416666666666667in"
height="2.353847331583552in"}

Note that when importing data from an Excel workbook that the Power BI
service creates both a new dataset and a new dashboard. However, you
might want just the dataset but not the dashboard. Feel free to delete
the dashboard if you do not need it.

1.  Delete the dashboard named **WingtipSalesData.xslx**.

2.  Expand the ellipse menu to the right of the
    **WingtipSalesData.xlsx** dashboard and selecting the
    **REMOVE** command.

![](media/image40.png){width="3.204064960629921in" height="2.0in"}

1.  When prompted, confirm you want to delete this dashboard.

![](media/image41.png){width="5.0in" height="1.0354472878390202in"}

1.  Your personal workspace now contains the **WingtipSalesData**
    dataset but there should not be any dashboards or reports.

![](media/image42.png){width="1.4929582239720034in"
height="2.2539949693788275in"}

1.  Expand the ellipse flyout menu (**…**) to the right of the
    **WingtipSalesData** dataset link just to see what menu commands are
    available from you to run on the new dataset you have just created.

![](media/image43.png){width="2.43002624671916in"
height="2.2394367891513562in"}

There is no need at this time to execute any of the commands in the
dataset flyout menu. You should just observe the commands that you can
execute on a dataset that’s been created by importing data from an excel
workbook. You can see the menu commands include **RENAME**, **REMOVE**,
**SCHEDULE REFRESH**, **REFRESH NOW**, **ANALYZE IN EXCEL**, **QUICK
INSIGHTS** and **SECURITY**

### Exercise 5: Create a New Power BI Report with Multiple Pages

Now that you have created a dataset, the next setup step involves
creating a new report with two pages of visualizations.

1.  Click the **WingtipSalesData** link in the **Datasets** section of
    the navigation menu.

![](media/image44.png){width="1.5241863517060368in" height="0.82in"}

1.  When you navigate to a dataset such as **WingtipSalesData**, the
    Power BI service displays a page in report design mode as shown in
    the following screenshot. Locate the **Fields** list for the dataset
    on the right-hand side of the page.

![](media/image45.png){width="6.0in" height="2.3695319335083114in"}

1.  In the **Fields** list on the right-hand side of the page, click the
    checkbox beside **Fiscal Year** and then select the checkbox beside
    ﻿**Sales Revenue**.

    ![](media/image46.png){width="1.0138046806649168in" height="1.6in"}

2.  This should create a table visual in the new report as shown in the
    following screenshot.

![](media/image47.png){width="2.178323490813648in"
height="1.8450699912510937in"}

1.  ﻿Change the visual type from a table to a line chart by clicking the
    **Line chart** button in the **Visualizations** list.

![](media/image48.png){width="2.2394367891513562in"
height="1.6198556430446194in"}

1.  At this point, you should see that the visual on the report now
    displays a line chart.

![](media/image49.png){width="4.0578619860017495in"
height="2.3098600174978126in"}

1.  Next, you will add a new dimension to your visual to show how sales
    revenue is distributed across product categories. First, make sure
    the visual with the line chart is selected and then drag-and-drop
    the **Category** field from the **Fields** list into the **Legend**
    well in the **Visualizations** pane as shown in the
    following screenshot.

![](media/image50.png){width="2.027179571303587in"
height="1.7042246281714786in"}

1.  At this point, your visual should match the line chart shown in the
    following screenshot.

![](media/image51.png){width="5.9187860892388455in"
height="3.3521128608923885in"}

1.  Select the handle at the bottom-right corner of the visualization
    and resize it so it takes up the width of the current report page.

![](media/image52.png){width="6.9in" height="1.9166666666666667in"}

1.  Reposition the Line chart’s legend.

2.  Make sure the visual with the Line chart is selected.

3.  In the **Visualizations** pane, click the pen icon to activate the
    **Format** properties pane.

4.  In the **Legend** section, locate the **Position** property and
    update it to **Right**.

5.  The legend should now be displayed in the upper right corner of the
    line chart visual.

![](media/image53.png){width="6.621978346456693in" height="1.82in"}

1.  Now you will add a second visualization to the current report page.
    Begin by clicking the white space under the visualization so that
    the visualization is no longer selected. Next, return to the
    **Fields** list and select the checkbox beside the
    **Category** field. Next, select the checkbox beside the
    **Subcategory** field and then select the checkbox beside the
    **Sales Revenue** field.

![](media/image54.png){width="1.8309864391951005in"
height="2.9499234470691165in"}

1.  Now, the current report page should display a second visual like the
    one shown in the following screenshot. Note that you will likely
    need to resize this visual so it displays all its data without
    clipping out the content on the right-hand side.

![](media/image55.png){width="2.901408573928259in"
height="1.567544838145232in"}

1.  Change the type of visualization from table to matrix by clicking
    the **Matrix** button in the **Visualizations** list.

![](media/image56.png){width="1.4725853018372703in"
height="1.3802810586176728in"}

1.  Now, the second visualization should display as a matrix instead of
    a standard table.

![](media/image57.png){width="3.0769225721784776in" height="2.0in"}

1.  Inside the matrix, click on the **Sales Revenue** column header to
    resort the data in the matrix so that the product categories and
    subcategories with the highest amounts of sales revenue are sorted
    to the top of the matrix.

![](media/image58.png){width="3.0393372703412074in"
height="2.098591426071741in"}

1.  Increate the font size of the matrix visual.

2.  Make sure the visual with the matrix you have just created is
    selected as the active visual.

3.  Find the **Text Size** property in the **General** section of the
    **Format** properties pane and set the **Text Size** to **10pt**.

![](media/image59.png){width="5.886435914260717in"
height="2.9295767716535432in"}

1.  Customize the column header row of the matrix.

2.  Make sure the visual with the matrix you have just created is
    selected as the active visual.

3.  Find the **Column headers section** in the **Format**
    properties pane.

4.  Set the **Font color** property to **white** and the **Background
    color** property to **black**.

![](media/image60.png){width="1.5932206911636047in"
height="1.7206780402449693in"}

1.  You should see the row with the column header is now stylized.

![](media/image61.png){width="3.6325984251968504in"
height="2.1549300087489063in"}

1.  Add a third visual to the current report page.

2.  Click the white space on the report page outside of the two existing
    visuals so that neither visual is selected.

3.  Return to the **Fields** list and select the checkbox beside the
    **Sales Region** field.

4.  Select the checkbox beside the **Sales Revenue** field.

5.  After creating the new visual, change the visualization type to a to
    a **Clustered bar chart** using the **Visualizations** list.

![](media/image62.png){width="1.6666666666666667in" height="1.25in"}

1.  Using the mouse, reposition the new visual so it takes up the bottom
    right corner of the page.

![](media/image63.png){width="5.791666666666667in"
height="3.397777777777778in"}

1.  Add a legend to the Clustered bar chart to visualize how revenue
    breaks down across product categories.

2.  Make sure the Clustered bar chart visual is selected.

3.  Click on the chart icon in the **Visualizations** task pane so you
    can edit the **Field** properties of the new **Clustered bar
    chart**.

4.  Drag the **Category** field from the **Fields** list into the
    **Legend** well in the **Field** properties pane.

![](media/image64.png){width="1.7711865704286964in"
height="1.919009186351706in"}

1.  You should not see revenue for each sales region is further broken
    out by product category.

![](media/image65.png){width="4.594811898512686in"
height="2.0845067804024495in"}

1.  Modify the position of the legend for the Clustered bar chart to
    the right.

![](media/image66.png){width="1.6666666666666667in"
height="1.1666666666666667in"}

1.  Your Clustered bar chart should now look like the one in the
    following screenshot.

![](media/image67.png){width="4.873239282589676in"
height="2.198899825021872in"}

If you have time, you might explore the other options available for
editing the appearance of a visualization by examining the other options
that are available on the **Visualizations** task pane when a visual is
selected. Note that the set of available options change depending on
what type of visual is selected.

1.  Now it is time to save the report. Begin by changing the name of the
    current page. Locate the report page name section at the bottom left
    of the current page and observe that the page has been given an
    initial name of **Page 1**.

![](media/image68.png){width="5.3813560804899385in"
height="1.1173162729658792in"}

1.  Double click on the page name of **Page 1** to enter edit mode and
    then update the page name to **Sales by Product Category**,

![](media/image69.png){width="2.740972222222222in"
height="0.3888888888888889in"}

1.  Save the report by dropping down the reports **File** menu and
    selecting the **Save As** menu command.

![](media/image70.png){width="3.855932852143482in"
height="2.0523512685914262in"}

1.  When prompted, enter a report name of **Product Sales** and click
    the **Save** button.

![](media/image71.png){width="4.533898731408574in"
height="1.1600601487314086in"}

1.  After saving the **Product Sales** report, you should be able to see
    a link for it in the **Reports** section of the
    left-hand navigation.

![](media/image72.png){width="1.6355927384076991in"
height="1.554838145231846in"}

1.  Now, add a second page to the **Product Sales** report. Accomplish
    this by clicking the button with the plus (+) sign to the right of
    the page name. The Power BI service will respond by creating a
    second page named **Page 1**.

![](media/image73.png){width="3.320754593175853in"
height="0.30188648293963255in"}

1.  Change the name of the second page from **Page 1** to **Sales by
    Product**.

![](media/image74.png){width="3.773584864391951in"
height="0.3314632545931758in"}

1.  On the new **Sales by Product** page, add a new visual by selecting
    the checkbox beside the **Product** field from the **Fields** list.
    This should create a simple table visual with a list of products.
    Resize the height of the visual to display all products at once
    without the need for a scrollbar.

![](media/image75.png){width="1.4716983814523183in"
height="2.5983464566929135in"}

1.  Change the type of visualization from a table to a slicer by
    clicking the **Slicer** button in the **Visualizations** list.

![](media/image76.png){width="1.9929571303587053in"
height="1.1830982064741906in"}

1.  Now that the visualization has been changed to a slicer, you should
    see that each product has an associated checkbox.

![](media/image77.png){width="1.6603772965879264in"
height="2.9543055555555555in"}

Keep in mind that this slicer visual adds the ability for the current
user to intact with this report by selecting one or more products using
these checkboxes. When a user changes the selection of products, the
Power BI service will automatically refresh the other visualizations on
the page by filtering the results using the selected product or
products. Learning how to make reports interactive is a key to creating
effective BI solutions with Power BI.

1.  Add a second visualization to **Sales by Product** page.

2.  Click whitespace in the report to ensure the first visualization is
    not selected.

3.  Create a new visualization by selecting the checkbox for the **Sales
    Revenue** field and then selecting the checkbox for the **Fiscal
    Year** field.

4.  Use the mouse to reposition the new visual so it takes up the top
    right corner of the page.

5.  The new visual as a bar chart should now match the
    following screenshot.

![](media/image78.png){width="5.830508530183727in"
height="2.073070866141732in"}

Note that the bar chart has been created with the fiscal years
decreasing as it moves from left to right. In the next step you will
reverse the order of the columns in this bar chart so that columns for
earlier years are sorted to the right and that later years are sorted
left.

1.  Click the flyout menu at the top-right corner of the bar chart
    visual and select **Sort By Fiscal Year** menu command.

![](media/image79.png){width="5.720766622922135in"
height="2.3645833333333335in"}

1.  The bar chart should now display its bars with fiscal year
    increasing as you move to the right.

![](media/image80.png){width="5.760416666666667in"
height="1.9201388888888888in"}

1.  With the bar chart selected, look inside the **Format** properties
    pane and locate the **Data colors** section. Inside the **Data
    colors** section, you should see that the **Show all** property is
    set to **Off**.

![](media/image81.png){width="1.6979166666666667in"
height="2.739495844269466in"}

1.  Change the **Show all** property to **On**.

2.  Assign a different color to each of the 4 fiscal years.

![](media/image82.png){width="1.5742005686789151in"
height="2.3333333333333335in"}

1.  Your bar chart should now display bars that have a different color
    for each year.

![](media/image83.png){width="5.520833333333333in"
height="1.8658727034120735in"}

1.  Add a third visual to the page.

2.  Click whitespace in the report to ensure the neither of the two
    visualizations are currently selected.

3.  Create a third visualization by selecting the checkbox for the
    **Sales Revenue** field and then selecting the checkbox for the
    **Sales Region** field.

4.  Use the mouse to reposition the new visual so it takes up the bottom
    right corner of the page.

5.  The new visual should now match the following screenshot.

![](media/image84.png){width="5.04038167104112in"
height="2.9583333333333335in"}

1.  Modify the **Data colors** section in the **Format** properties pane
    to give each column its own unique color.

![](media/image85.png){width="5.114583333333333in"
height="1.6574376640419948in"}

1.  Save you work by executing the **Save** command from the
    **File** menu.

![](media/image86.png){width="4.270833333333333in"
height="1.7083333333333333in"}

1.  Test out the interactive effect of selecting products in the slicer.

2.  Select one product at a time.

![](media/image87.png){width="2.593264435695538in" height="1.75in"}

1.  Observing how the two other visualizations on the page automatically
    refresh to show sales data for one product at a time.

![](media/image88.png){width="6.53125in" height="3.8316666666666666in"}

1.  Play the role of a business analyst and determine which products
    have the most positive increases in sales revenue from year to year.
    Also, find the products with downward trending sales. If you examine
    the sales data for the **Crate o’ Cranyons**, you can sales revenue
    for this is trending in the wrong direction over the last
    four years. What other products are shows decreasing sales in this
    set of 32 products?

Now that you have created a report with multiple pages, it is time to
move on to the next exercise where you will create a new dashboard and
then you will test sharing this dashboard with another user in your
Office 365 trial tenant.

### Exercise 6: Create and Share a Power BI Dashboard

While you have already created a dataset and a report, you must create a
dashboard to effectively share a customized BI solution with other
users. This final setup task will walk you through the steps of creating
and sharing a Power BI dashboard.

1.  Navigate to the **Sales by Product Category** page of the **Product
    Sales** report.

2.  Inspect the Clustered bar chart with product categories. Locate and
    click the button with the thumbtack icon which is used to pin a
    report visualization to a dashboard.

![](media/image89.png){width="5.330508530183727in"
height="2.3691152668416446in"}

1.  When you click the button with the thumbtack icon, you will be
    prompted with the dialog which asks you where to pin
    the visualization. Select the option to pin the visualization to a
    **New Dashboard** and give the new dashboard a name of **Product
    Sales**. When the **Pin to Dashboard** form is filled out like the
    one shown in the following screenshot, click the **Pin** button.

![](media/image90.png){width="4.635592738407699in"
height="2.2496259842519684in"}

1.  At this point, the new **Product Sales** dashboard should be created
    and a link to it should appear in the left navigation menu.

![](media/image91.png){width="1.3983048993875766in"
height="2.0974573490813646in"}

1.  Navigate to the **Sales by Product** page of **Product Sales**
    report and follow the same steps to pin the bar chart visualization
    showing sales revenue by fiscal year to the **Product
    Sales** dashboard.

![](media/image92.png){width="4.401407480314961in"
height="2.1126760717410322in"}

1.  Remain on the **Sales by Product** page of **Product Sales** report
    and follow the same steps to pin the bar chart visualization showing
    sales revenue by sales region to the **Product Sales** dashboard.

![](media/image93.png){width="4.422534995625547in"
height="2.063849518810149in"}

1.  Click on the **Product Sales** link in the **Dashboards** section of
    the left navigation menu to display the **Product Sales** dashboard.
    You should be able to verify that you see three tiles that have been
    created from the three report visualization that you pinned to
    this dashboard.

![](media/image94.png){width="5.028168197725284in"
height="3.3521117672790903in"}

1.  Note that you can move or resize the tiles inside the dashboard.
    This is due to the fact that you are the dashboard author and you
    are in dashboard edit mode. Use your mouse to rearrange the tiles in
    the dashboard to match the screenshot below.

![](media/image95.png){width="4.454093394575678in"
height="2.9859153543307086in"}

1.  Experiment by clicking on the tiles in the dashboard. You will find
    that clicking a tile will navigate the user to the report and page
    that contains the visualization which was pinned to the dashboard.

2.  Now, it is time to test sharing a Power BI dashboard. Start by
    dropping down the fly out menu for the **Product Sales** dashboard
    and clicking the **SHARE** menu command .

![](media/image96.png){width="2.9073829833770777in"
height="1.8450699912510937in"}

1.  At this point, you are prompted with the **Share dashboard** page
    where you can add the users and/or groups with which you want to
    share your new dashboard. Enter the email address of the secondary
    user account that you created earlier in setup task five that has an
    email address of **JamesB@CptPowerBiTenant.onMicrosoft.com**. After
    you have entered the email address, click the **Share** button at
    the bottom of the page.

![](media/image97.png){width="2.3952077865266843in"
height="2.9718318022747154in"}

1.  Once the dashboard has been successfully shared, you should be able
    to confirm that the secondary user has access to this dashboard by
    returning to the **Share dashboard** dialog and examining the
    **Access** tab of the **Share dashboard** page as shown in the
    following screenshot.

![](media/image98.png){width="2.804314304461942in"
height="2.7542377515310585in"}

Now you have completed the steps to share the dashboard. The final step
is to test the experience of a user who is not the dashboard author, but
instead a dashboard consumer. This will require that you sign out of the
Power BI service and then sign back in under the identity of the
secondary user account. By accessing the shared dashboard in this
fashion, you will be able to observe the typical experience of a
dashboard consumer when accessing a dashboard that has been shared by
another user.

1.  Drop down the user menu from the top, right-hand corner of the page
    and click the Sign out command.

![](media/image99.png){width="1.9451443569553806in"
height="1.1549300087489063in"}

1.  Now, sign back in using the account name and the password of the
    secondary user account for which you just shared the **Product
    Sales** dashboard.

![](media/image100.png){width="5.3125in" height="1.4756944444444444in"}

1.  Once you have signed in, click the **Mail** tile in the Application
    Launcher accessible via the **Waffle** **Button**.

2.  When you first log into mail, you will be prompted to set a
    time zone. Once you set the time zone, you should be redirected to
    the Exchange Online inbox for the secondary user.

3.  Once you are able to access the inbox for the secondary user, you
    should be able to verify that the Power BI service has sent this
    user a notification email message informing the user that the
    Product Sales dashboard that has been shared. In the body of the
    email message, click the **Open Product Sales** link to navigate to
    the new dashboard.

![](media/image101.png){width="4.71875in" height="1.5479844706911636in"}

1.  At this point, you will be taken to a page which shows the personal
    workspace for the current user and displays the page for the Product
    Sale dashboard.

![](media/image102.png){width="4.09375in" height="2.5336832895888013in"}

1.  Expand the left navigation menu. Take note that this user can see
    the **Product Sales** dashboard link in the left navigation menu but
    this user does not see any links for the underlying report
    or dataset.

![](media/image103.png){width="1.59375in" height="1.5946741032370955in"}

Note that Power BI does not include links to provide the dashboard
consumer with direct access to the report or the dataset behind the
dashboard. However, Power BI does supply the dashboard consumer with
indirect access to the report and the dataset behind the dashboard. It’s
just that the dashboard consumer can only access the report and dataset
by interacting with the dashboard. One key benefit is that this approach
keeps the left navigation less cluttered when the user is accessing many
different shared dashboards.

1.  Navigate to the **Product Sales** dashboard and observe that the
    dashboard page is in read-only view. The user is not able to delete,
    move or resize any of the tiles. Only the dashboard author is able
    to edit this dashboard page.

2.  On the **Product Sales** dashboard, experiment by clicking on the
    dashboard tile showing sales revenue by fiscal year. This will allow
    you to navigate to the **Sales by Product** page of the **Product
    Sales** report. Interact with the report page by using the slicer to
    filter and analyze the underlying data and see how individual
    products are selling from year to year.

![](media/image104.png){width="7.0in" height="3.1251738845144357in"}

### Exercise 7: Get Quick Insights on the WingtipSalesData Dataset

In this exercise, you will run a Power BI command to generate quick
insights for the WingtipSalesData dataset.

1.  Log out from the JamesB account and then log back in using your
    primary user account.

2.  Drop down the fly out menu for the **WingtipSaleData** and click the
    **VIEW INSIGHTS** menu command.

![](media/image105.png){width="2.8316130796150483in"
height="2.457626859142607in"}

1.  After a second or two, the Power BI service should generate a page
    with the title **Quick Insights for WingtipSalesData**. Take a few
    minutes to review all the quick insights that have been generated.

![](media/image106.png){width="7.490277777777778in"
height="3.2979166666666666in"}

Congratulations. You have made it to the end of this setup guide and you
have now created and configured a test environment in which you can
begin to create and implement custom BI solutions using the Power BI
platform.
