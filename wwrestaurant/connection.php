<?php
$db_server = "localhost";  //credentialele nu trebuie schimbate pentru xampp
$username = "root";
$password = "";
$db_name = "wwrestaurant";

$conn = new mysqli($db_server, $username, $password, $db_name);

if($conn -> connect_error){
    die("Connection failed: ". $conn->connect_error);
}
echo "CONNECTION SUCCESSFUL";

$sql = "INSERT INTO users (username, password, type)
        VALUES ('macheciau', 'parola123', 'manager')";

mysqli_query($conn, $sql);


?>