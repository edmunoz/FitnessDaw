
//
// Funciones Cookie
// Escrito por: Bill Dortch, hIdaho Design
// Las funciones siguientes se ceden al dominio público. 
function encode (str) {
var dest = "";
var len = str.length;
var index = 0;
var code = null;
for (var i = 0; i < len; i++) {
var ch = str.charAt(i);
if (ch == " ") code = "%20";
else if (ch == "%") code = "%25";
else if (ch == ",") code = "%2C";
else if (ch == ";") code = "%3B";
else if (ch == "\b") code = "%08";
else if (ch == "\t") code = "%09";
else if (ch == "\n") code = "%0A";
else if (ch == "\f") code = "%0C";
else if (ch == "\r") code = "%0D";
if (code != null) {
dest += str.substring(index,i) + code;
index = i + 1;
code = null;
}
}
if (index < len)
dest += str.substring(index, len);
return dest;
}

function decode (str) {
var dest = "";
var len = str.length;
var index = 0;
var code = null;
var i = 0;
while (i < len) {
i = str.indexOf ("%", i);
if (i == -1)
break;
if (index < i)
dest += str.substring(index, i);
code = str.substring (i+1,i+3);
i += 3;
index = i;
if (code == "20") dest += " ";
else if (code == "25") dest += "%";
else if (code == "2C") dest += ",";
else if (code == "3B") dest += ";";
else if (code == "08") dest += "\b";
else if (code == "09") dest += "\t";
else if (code == "0A") dest += "\n";
else if (code == "0C") dest += "\f";
else if (code == "0D") dest += "\r";
else {
i -= 2;
index -= 3;
}
} 
if (index < len)
dest += str.substring(index, len);
return dest;
}

function getCookieVal (offset) {
var endstr = document.cookie.indexOf (";", offset);
if (endstr == -1)
endstr = document.cookie.length;
return decode(document.cookie.substring(offset, endstr));
}

function GetCookie (name) {
var arg = name + "=";
var alen = arg.length;
var clen = document.cookie.length;
var i = 0;
while (i < clen) {
var j = i + alen;
if (document.cookie.substring(i, j) == arg)
return getCookieVal (j);
i = document.cookie.indexOf(" ", i) + 1;
if (i == 0) break; 
}
return null;
}

function SetCookie (name, value, expires) {
document.cookie = name + "=" + encode(value) + ((expires == null) ? "" : ("; expires=" + expires.toGMTString()));
}

//
//http://www.yomaster.com
function arrayOfDaysInMonths(isLeapYear)
{
this[0] = 31;
this[1] = 28;
if (isLeapYear)
this[1] = 29;
this[2] = 31;
this[3] = 30;
this[4] = 31;
this[5] = 30;
this[6] = 31;
this[7] = 31;
this[8] = 30;
this[9] = 31;
this[10] = 30;
this[11] = 31;
}
function daysInMonth(month, year)
{
var isLeapYear = (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));
var monthDays = new arrayOfDaysInMonths(isLeapYear);
return monthDays[month];
}
function calendar()
{
var monthNames = "EneFebMarAbrMarJunJulAgoSepOctNovDic";
var today = new Date();
var day = today.getDate();
var month = today.getMonth();
var year = today.getYear() + 0;
var numDays = daysInMonth(month, year);
var firstDay = today;
firstDay.setDate(1);
var startDay = firstDay.getDay();
var column = 0;

document.write("<CENTER>");
document.write("<TABLE BORDER>");
document.write("<TR><TH COLSPAN=7>");
document.write(monthNames.substring(3*month, 3*(month + 1)) + " " + year);
document.write("<TR><TH>Dom<TH>Lun<TH>Mar<TH>Mié<TH>Jue<TH>Vie<TH>Sab");
document.write("<TR>");
for (i = 0; i < startDay; i++)
{
document.write("<TD>");
column++;
}
for (i=1; i <= numDays; i++)
{
var s = "" + i;
if ((GetCookie("d"+i) != null))
s = s.fontcolor("#FF0000");
s = s.link("javascript:dayClick(" + i + ")")
document.write("<TD>" + s);

if (++column == 7)
{
document.write("<TR>");
column = 0;
}
}
document.write("</TABLE>");
document.writeln("</CENTER>");
}

function dayClick(day)
{
var expdate = new Date ();
expdate.setTime (expdate.getTime() + (24 * 60 * 60 * 1000));
var prefix = "d";
var theCookieName = prefix + day;
var theDayclickedReminder = GetCookie(theCookieName);
if (theDayclickedReminder != null) {
alert("La cita del día " + day + " es:" + theDayclickedReminder);
}
if (confirm("¿Desea escribir una cita para el día " + day + " de este mes?"))
{
x = prompt("Escriba una cita para el día "+ day + " de este mes", theDayclickedReminder);
SetCookie (theCookieName, x, expdate);
} // end if
}