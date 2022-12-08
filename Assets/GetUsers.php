<?php
include_once('connection.php');
   $sql = "SELECT * FROM users";
   $result = $conn->query($sql);

   if($result->num_rows > 0){
        while($row = $result->fetch_assoc()){
            echo "username: " . $row["username"]. " - Level: ". $row["level"];
        }
   }else{
    echo "0 results";
   }
   $conn->close();
?>
