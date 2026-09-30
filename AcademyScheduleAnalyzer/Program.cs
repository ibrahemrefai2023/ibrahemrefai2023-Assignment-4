

using AcademyScheduleAnalyzer;
using BenchmarkDotNet.Running;
using System.Text;


//BenchmarkRunner.Run<Benchmark>();
string[] sessionNames =
{
"C# Basics",
"Arrays",
"Functions",
"Date and Time",
"Exception Handling"
};
DateTime[] sessionDates =
{
new DateTime(2026, 9, 10, 18, 0, 0),
new DateTime(2026, 9, 13, 18, 0, 0),
new DateTime(2026, 9, 17, 18, 0, 0),
new DateTime(2026, 9, 20, 18, 0, 0),
new DateTime(2026, 9, 24, 18, 0, 0)
};
int[] sessionDurations =
{
180,
240,
180,
240,
180
};

void DisplayAllSessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
{
    Console.WriteLine("Display All Sessions");
    foreach (var session in sessionNames)
    {
        int index = Array.IndexOf(sessionNames, session);
        Console.WriteLine($"Session: {session}, Date: {sessionDates[index]}, Duration: {sessionDurations[index]} minutes");
    }
}

void SearchForASession()
{
    Console.WriteLine("");
    Console.WriteLine("Search For ASession");
    Console.WriteLine("Please enter a valid session name.");
    string sessionName = Console.ReadLine() ?? "";

    if (!string.IsNullOrWhiteSpace(sessionName))
    {
        int index = Array.IndexOf(sessionNames, sessionName);
        if (index >= 0)
        {
            Console.WriteLine($"Session: {sessionNames[index]}, Date: {sessionDates[index]}, Duration: {sessionDurations[index]} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }

    }
    else
    {
        Console.WriteLine("Please enter a valid session name.");
    }
}

void SortSessionNamesAlphabetically()
{
    Console.WriteLine("");
    Console.WriteLine("Sort Session Names Alphabetically");
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy, sessionNames.Length);
    Array.Sort(sessionNamesCopy);
    foreach (var session in sessionNamesCopy)
    {
        Console.WriteLine($"Session: {session}");
    }
}

void ReverseSessionNames()
{
    Console.WriteLine("");
    Console.WriteLine("Reverse Session Names");
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy, sessionNames.Length);
    Array.Reverse(sessionNamesCopy);
    foreach (var session in sessionNamesCopy)
    {
        Console.WriteLine($"Session: {session}");
    }
}
void FindSessionIndex()
{
    Console.WriteLine("");
    Console.WriteLine("Find Session Index");
    Console.WriteLine("Enter session name:");
    string sessionName = Console.ReadLine() ?? "";
    var index = Array.IndexOf(sessionNames, sessionName);
    Console.WriteLine($"Index: {index}");
}
void CheckIfASessionExists()
{
    Console.WriteLine("");
    Console.WriteLine("Check If A Session Exists");
    Console.WriteLine("Enter session name:");
    string sessionName = Console.ReadLine() ?? "";
    bool exists = Array.Exists(sessionNames, name => name == sessionName);
    if (exists)
    {
        Console.WriteLine("Session exists.");
    }
    else
    {
        Console.WriteLine("Session does not exist.");
    }
}
void FindASession()
{
    Console.WriteLine("");
    Console.WriteLine("Find A Session");
    Console.WriteLine("Enter session name:");
    string sessionName = Console.ReadLine() ?? "";
    var result = Array.Find(sessionNames, name => name == sessionName);
    if (!string.IsNullOrWhiteSpace(result))
    {
        Console.WriteLine($"Session: {result}");
    }
    else
    {
        Console.WriteLine("Session not found.");
    }
}
void FindASessionIndexUsingACondition()
{
    Console.WriteLine("");
    Console.WriteLine("Find A Session Index Using A Condition");
    Console.WriteLine("Enter session name:");
    string sessionName = Console.ReadLine() ?? "";
    var index = Array.FindIndex(sessionNames, name => name == sessionName);
    Console.WriteLine($"Index: {index}");
}
void CopyAnArray()
{
    Console.WriteLine("");
    Console.WriteLine("Copy An Array");
    string[] sessionNamesCopy = new string[sessionNames.Length];
    Array.Copy(sessionNames, sessionNamesCopy, sessionNames.Length);
    Console.WriteLine("Copied Array Items:");
    foreach (var session in sessionNamesCopy)
    {
        Console.WriteLine($"Session: {session}");
    }
    Console.WriteLine(" Original Array Items:");
    foreach (var session in sessionNames)
    {
        Console.WriteLine($"Session: {session}");
    }
}
(int totalDuration, int averageDuration, int shortestDuration, int longestDuration) DurationAnalysis()
{
    Console.WriteLine("");
    Console.WriteLine("Duration Analysis");
    int totalDuration = 0;
    int averageDuration = 0;
    int shortestDuration = 0;
    int longestDuration = 0;
    int count = 0;
    int sessionDurationsNumber = sessionDurations.Length;
    int secondDurationIndex = 1;
    foreach (int duration in sessionDurations)
    {
        totalDuration += duration;
        averageDuration = totalDuration / sessionDurationsNumber;
        if (count <= sessionDurations.Length - 1)
        {
            if (secondDurationIndex <= sessionDurations.Length - 1)
            {
                if (sessionDurations[count] > sessionDurations[secondDurationIndex])
                    longestDuration = sessionDurations[count];
                if (sessionDurations[count] < sessionDurations[secondDurationIndex])
                    shortestDuration = sessionDurations[count];
                secondDurationIndex++;
            }
        }
        count++;
    }

    var copiedSessionDurations = new int[sessionDurations.Length];
    Array.Copy(sessionDurations, copiedSessionDurations, sessionDurations.Length);
    Array.Sort(copiedSessionDurations);
    foreach (int duration in copiedSessionDurations)
    {
        Console.WriteLine($"duration : {duration}");
    }
    return (totalDuration, averageDuration, shortestDuration, longestDuration);
}

void GetSessionEndTime()
{
    Console.WriteLine("");
    Console.WriteLine("Get Session EndTime");
    foreach (var session in sessionDates)
    {
        var index = Array.IndexOf(sessionDates, session);
        var sessionEndTime = sessionDates[index].AddMinutes(sessionDurations[index]);
        Console.WriteLine($"Session: {session}, Session Date: {sessionEndTime}");
    }
}

void ReadSessionDate()
{
    Console.WriteLine("");
    Console.WriteLine("Read Session Date");
    foreach (var session in sessionNames)
    {
        var index = Array.IndexOf(sessionNames, session);
        Console.WriteLine($"Session: {session}, EndTime: {sessionDates[index]}");
    }
}

string BuildReportUsingString()
{
    Console.WriteLine("");
    Console.WriteLine("Build Report Using String");
    return $"report";
}

string BuildReportUsingStringBuilder()
{
    Console.WriteLine("");
    Console.WriteLine("Build Report Using String Builder");
    var report = new StringBuilder("report");
    return report.ToString();
}

void RefMethod(ref int value)
{
    Console.WriteLine("");
    Console.WriteLine("RefMethod");
    value = 20;
    Console.WriteLine($"value : {value}");
}

(double sessionIndex, double sessionDuration) OutMethod(out string sessionName)
{
    Console.WriteLine("");
    Console.WriteLine("OutMethod");
    Console.WriteLine("enter a session name");
    sessionName = Console.ReadLine() ?? "";
    double sessionIndex = 0;
    double sessionDuration = 0;
    foreach (var session in sessionNames)
    {
        if (session == sessionName)
        {
            sessionIndex = Array.IndexOf(sessionNames, session);
            sessionDuration = sessionDurations[(int)sessionIndex];
            break;
        }
    }
    return (sessionIndex, sessionDuration);
}

void ReferenceTypeWithoutRef(int[] normalArray)
{
    Console.WriteLine("");
    Console.WriteLine("Reference Type Without Ref");
    normalArray[0] = 10;

    Console.WriteLine("Display Array After Calling The Function");
    foreach (var item in normalArray)
    {
        Console.WriteLine($"item : {item}");
    }
}

void CalculateTotalDuration(params int[] numbers)
{
    Console.WriteLine("");
    Console.WriteLine("Calculate Total Duration");
    long totalDuration = 0;
    foreach (var num in numbers)
    {
        totalDuration += num;
    }
    Console.WriteLine($"totalDuration is : {totalDuration}");
}
void SessionDateDetails()
{
    Console.WriteLine("");
    Console.WriteLine("Session Date Details");
    Console.WriteLine("select or search for a session");
    string session = Console.ReadLine() ?? "";
    foreach (string sessionName in sessionNames)
    {
        if (sessionName == session)
        {
            var index = Array.IndexOf(sessionNames, sessionName);
            Console.WriteLine($"Full date : {sessionDates[index]}");
            Console.WriteLine($"Day  : {sessionDates[index].Day}");
            Console.WriteLine($"Year : {sessionDates[index].Year}");
            Console.WriteLine($"Month : {sessionDates[index].Month}");
            Console.WriteLine($"Day of week : {sessionDates[index].DayOfWeek}");
            TimeOnly.TryParse(sessionDates[index].ToString(), out var startTime);
            Console.WriteLine($"Start time :  {startTime} ");
            Console.WriteLine($"Duration :  {sessionDurations[index]}");
            DateTime endDateTime = sessionDates[index]
           .AddMinutes(sessionDurations[index]);
            TimeOnly endTime = TimeOnly.FromDateTime(endDateTime);
            Console.WriteLine($"End time :  {endTime}");
        }
    }
}

void DateDifference()
{
    Console.WriteLine("");
    Console.WriteLine("Date Difference");
    Console.WriteLine("please enter first session name");
    var sessionOne = Console.ReadLine();
    Console.WriteLine("please enter second session name");
    var sessionTwo = Console.ReadLine();
    var firstDateTime = new DateTime();
    var secondDateTime = new DateTime();
    foreach (var session in sessionNames)
    {
        if (sessionOne == session)
        {
            var index = Array.IndexOf(sessionNames, session);
            firstDateTime = sessionDates[index];
        }
        if (sessionTwo == session)
        {
            var index = Array.IndexOf(sessionNames, session);
            secondDateTime = sessionDates[index];
        }
    }
    TimeSpan timeSpanTotalDaysDifference = firstDateTime - secondDateTime;
    var totalDays = timeSpanTotalDaysDifference.TotalDays;
    var totalHours = timeSpanTotalDaysDifference.TotalHours;
    Console.WriteLine($"First Session : {firstDateTime}");
    Console.WriteLine($"Second Session : {secondDateTime}");
    Console.WriteLine($"totalDays : {totalDays}");
    Console.WriteLine($"totalHours : {totalHours}");
}
void FindTheNextSession()
{
    Console.WriteLine("");
    Console.WriteLine("Find The Next Session");
    var totalDays = int.MaxValue;
    var totalHours = 0;
    var index = 0;
    foreach (var sessionDate in sessionDates)
    {
        if ((sessionDate - DateTime.Now).TotalDays < totalDays)
        {
            totalDays = Math.Abs((int)(sessionDate - DateTime.Now).TotalDays);
            totalHours = Math.Abs((int)(sessionDate - DateTime.Now).TotalHours);
            index = Array.IndexOf(sessionDates, sessionDate);
        }
    }
    Console.WriteLine("Next Session:");
    Console.WriteLine(sessionNames[index]);
    Console.WriteLine(sessionDates[index]);
    Console.WriteLine(TimeOnly.FromDateTime(sessionDates[index]));
    Console.WriteLine("Time Remaining:");
    Console.WriteLine(totalDays + " Days");
    Console.WriteLine(totalHours + " Hours");
}

void PastAndUpcomingSessions()
{
    Console.WriteLine("");
    Console.WriteLine("Past And Upcoming Sessions");
    foreach (var session in sessionNames)
    {
        var index = Array.IndexOf(sessionNames, session);
        var sessionDate = sessionDates[index];
        var compareWithCurrentDateTime = (sessionDate > DateTime.Now) ? "Upcoming" : "Past";
        Console.WriteLine($"{session} {compareWithCurrentDateTime} ");
    }

}
DateTime ReadAndValidateADate()
{
    Console.WriteLine("");
    Console.WriteLine("Read And Validate ADate");
    while (true)
    {
        Console.WriteLine("enter a valid datetime such as yyyy - MM - dd HH: mm");
        var datetime = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(datetime) && DateTime.TryParseExact(datetime, "yyyy - MM - dd HH: mm", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
        {
            return dateTime;
        }
        else
        {
            Console.WriteLine("enter a vaild datetime");
            continue;
        }
    }
}
void DateFormatting()
{
    Console.WriteLine("");
    Console.WriteLine("Date Formatting");
    Console.WriteLine("Selected Session is : C# Basics");
    var dateTime = sessionDates[0];
    Console.WriteLine(dateTime.ToString("yyyy-mm-dd"));
    Console.WriteLine(DateOnly.FromDateTime(dateTime));
    Console.WriteLine(dateTime.ToString($"dd {dateTime.ToString("MMM")} yyyy"));
    Console.WriteLine($"{dateTime.ToString("ddd")}" + " , " + dateTime.ToString($"dd {dateTime.ToString("MMM")} yyyy"));
    Console.WriteLine(TimeOnly.FromDateTime(dateTime));
}

void ExceptionHandlingMenuInput()
{
    Console.WriteLine("");
    Console.WriteLine("Date Formatting");
    while (true)
    {
        try
        {
            Console.WriteLine("enter a numeric option");
            var number = int.Parse(Console.ReadLine());
            break;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Exception : {ex}");
            Console.WriteLine($" ");
            Console.WriteLine("invalid number");
            continue;
        }
    }
}
void ExceptionHandlingInvalidArrayIndex()
{
    Console.WriteLine("");
    Console.WriteLine("Exception Handling Invalid Array Index");
    var index = 0;
    try
    {
        Console.WriteLine("enter an index");
        index = int.Parse(Console.ReadLine());
        if (index > sessionNames.Length)
            throw new IndexOutOfRangeException();
        Console.WriteLine($"index :{index}");
        Console.WriteLine($"Session: {sessionNames[index]}");
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine($"index :{index}");
        Console.WriteLine("The selected session index is out of range.");
    }
}

void ThrowAnException(int sessionDuration) //task 17 and 18
{
    Console.WriteLine("");
    Console.WriteLine("Throw An Exception");
    if (sessionDuration < 0)
        throw new ArgumentException();
    Console.WriteLine($"enter duration : {sessionDuration}");
    Console.WriteLine("duration accepted");
}
string BuildAScheduleReportUsingString()
{
    Console.WriteLine("");
    Console.WriteLine("Build A Schedule Report Using String");
    var result = "";
    foreach (var session in sessionNames)
    {
        var index = Array.IndexOf(sessionNames, session);
        string report = $"{session} - {sessionDates[index]} - {sessionDurations[index]} \n";
        result += report;
    }
    return result;
}
string BuildTheSameReportUsingStringBuilder()
{
    Console.WriteLine("");
    Console.WriteLine("Build The Same Report Using StringBuilder");
    StringBuilder result = new StringBuilder();
    foreach (var session in sessionNames)
    {
        var index = Array.IndexOf(sessionNames, session);
        string report = $"{session} - {sessionDates[index]} - {sessionDurations[index]} \n";
        result.Append(report);
    }
    return result.ToString();
}


DisplayAllSessions(sessionNames, sessionDates, sessionDurations);
SearchForASession();
SortSessionNamesAlphabetically();
ReverseSessionNames();
FindSessionIndex();
CheckIfASessionExists();
FindASession();
FindASessionIndexUsingACondition();
CopyAnArray();
var (totalDuration, averageDuration, shortestDuration, longestDuration) = DurationAnalysis();
Console.WriteLine($"totalDuration : {totalDuration}");
Console.WriteLine($"averageDuration : {averageDuration}");
Console.WriteLine($"shortestDuration : {shortestDuration}");
Console.WriteLine($"longestDuration : {longestDuration}");
GetSessionEndTime();
ReadSessionDate();
var stringReport = BuildReportUsingString();
Console.WriteLine($"stringReport : {stringReport}");
var StringBuilderReport = BuildReportUsingStringBuilder();
Console.WriteLine($"StringBuilderReport : {StringBuilderReport}");

Console.WriteLine("");
int value = 10;
Console.WriteLine($"the value is : {value} before change it using ref");
RefMethod(ref value);
string session = "";
var (sessionIndex, sessionDuration) = OutMethod(out session);
Console.WriteLine($"sessionIndex : {sessionIndex}");
Console.WriteLine($"sessionDuration : {sessionDuration}");

int[] normalArray = [0, 1, 2, 3, 4, 5, 6, 7];
Console.WriteLine("");
Console.WriteLine("Display Array before Calling The Function");
foreach (var item in normalArray)
{
    Console.WriteLine($"item : {item}");
}
ReferenceTypeWithoutRef(normalArray);
CalculateTotalDuration(435345345, 345345, 345345345, 435345435, 665756);
SessionDateDetails();
DateDifference();
PastAndUpcomingSessions();
FindTheNextSession();
DateFormatting();
//var validDateTime = ReadAndValidateADate();
//Console.WriteLine("");
//Console.WriteLine($"valid dateTime : {validDateTime}");
ExceptionHandlingMenuInput();
ExceptionHandlingInvalidArrayIndex();
Console.WriteLine("");
try//task 17 and 18
{
    Console.WriteLine("enter valid session duration");
    var duration = Convert.ToInt32(Console.ReadLine());
    ThrowAnException(duration);
}
catch (ArgumentException ex)
{
    Console.WriteLine("Duration must be greater than zero.");
}
finally
{
    Console.WriteLine("Input operation finished.");
}
var string_report = BuildAScheduleReportUsingString();
Console.WriteLine(string_report);
var stringBuilder_report = BuildTheSameReportUsingStringBuilder();
Console.WriteLine(stringBuilder_report);

Benchmark benchmark = new Benchmark();
benchmark.StringConcatenation();
benchmark.StringBuilderConcatenation();
benchmark.FirstIterationMethod();
benchmark.SecondIterationMethod();