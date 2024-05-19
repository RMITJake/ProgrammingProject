<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
﻿// Purpose: This file contains the Login model class, which represents a login in the database.
// The Login model contains the following properties:

using System.ComponentModel.DataAnnotations;
>>>>>>> main
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientConnect.Models;

public class Login
{
<<<<<<< HEAD
    [Column(TypeName = "char")]
    [StringLength(8)]
    public string LoginID { get; set; }

    public int UserID { get; set; }
    public virtual User User { get; set; }

=======
    // LoginID is required
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int LoginID { get; set; }

    // UserID is a foreign key to the User table
    public int UserID { get; set; }

    // User is a navigation property to the User table
    public virtual User User { get; set; }

    // PasswordHash is a hash of the user's password
>>>>>>> main
    [Column(TypeName = "char")]
    [Required, StringLength(94)]
    public string PasswordHash { get; set; }
}
