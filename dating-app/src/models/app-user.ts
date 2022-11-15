class User {
  id?: number;
  username?: string;
  email?: string;
  // PasswordHash? : any[];
  // PasswordSalt? : any[];
  constructor(id: number, name: string, email: string) {
    this.id = id;
    this.username = name;
    this.email = email;
  }
}
class UserToken {
  username: string = '';
  token: string = '';
}
class AuthUser {
  username: string = '';
  password: string = '';
}
export class Member {
  username: string = '';
  email: string = '';
  age: number = 0;
  knownAs: string = '';
  gender: string = '';
  city: string = '';
  introduction: string = '';
  avatar: string = '';
}

export class RegisterUser {
  username: string = '';
  password: string = '';
  email: string = '';
  dateOfBirth: Date = new Date();
  knownAs: string = '';
  gender: string = '';
  city: string = '';
  introduction: string = '';
  avatar: string = '';
}

export { User, UserToken, AuthUser };
