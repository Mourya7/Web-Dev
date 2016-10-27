<?php
session_start();
$expire = time() + 10; 
$path="/~mm2053/";
$domain="kelvin.ist.rit.edu";
$secure=false;
$loginDate=date("F j, Y, g:i a");

//set loggedIn cookie
//setcookie("loggedIn",$loginDate,$expire,$path,$domain,$secure);

$uname = $pwd = "";


if ($_SERVER["REQUEST_METHOD"] == "POST") 
{
  $uname = test_input($_POST["uname"]);
  $pwd = test_input($_POST["pwd"]); 
  
  
  if($uname!="" && $pwd!="")
  {
      if(validate_uname($uname)!==0 || validate_pwd($pwd)!==0)
      {
          echo"<h3> Invalid Login! </h3>";
      }
      else
      {
            $_SESSION['loggedIn']=true;
            header("Location:admin.php");
            exit();
      }
  }
  else
  {
      echo"<h3> Please enter a username and a password</h3>";
  }
   
}
//sanitization
function test_input($data) {
  $data = trim($data);
  $data = stripslashes($data);
  $data = htmlspecialchars($data);
  
  return $data;
}

function validate_uname($data)
{
    $reg = "admin";
    return strcmp($reg,$data);
}
    
function validate_pwd($data)
{
    $reg = "admin123";
    return strcmp($reg,$data);
}

?>