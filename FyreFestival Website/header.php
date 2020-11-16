<?php
  session_start();
?>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="style.css">
    <title>FMF</title>
  </head>
  <body>

  <!--Logo-->
    <div class="jumbotron jumbotron-fluid top-logo">
      <div class="container">
        <a href="index.php"><img class="mb-sm-4" src="img/FMFwhite.png" style="width:15%"></a><br>
        <a class="text-white" href="index.php"style="text-decoration: none">FYRE MUSIC FESTIVAL</a>
      </div>
    </div>

  <!--NavBar-->
    <nav class="navbar sticky-top navbar-expand-lg navbar-dark bg-dark">
      <a class="navbar-brand" href="index.php">
        <img src="img/fmfwhite.png" width="30" height="30" alt="">
      </a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <a class="nav-link" href="index.php">HOME <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">TICKETS</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">ARTISTS</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">INFO</a>
          </li>
        </ul>
        <form class="form-inline my-2 my-lg-0">
          <input class="form-control mr-sm-2" type="email" placeholder="Email" aria-label="Email">
          <input class="form-control mr-sm-2" type="password" placeholder="Password" aria-label="Password">
          <div class="btn-group" role="group">
            <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">LOGIN</button>
            <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">SIGNUP</button>
          <div>
        </form>
      </div>
    </nav>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="js/bootstrap.js"></script>
  </body>
</html>