// Purpose: This file contains the Login model class, which represents a login in the database.
// The Login model contains the following properties:

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminWebAPI.Models;

public class Login
{
    // LoginID is required
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int LoginID { get; set; }

    // UserID is a foreign key to the User table
    public int UserID { get; set; }

    // User is a navigation property to the User table
    public virtual User User { get; set; }

    // PasswordHash is a hash of the user's password
    [Column(TypeName = "char")]
    [Required, StringLength(94)]
    public string PasswordHash { get; set; }
}
