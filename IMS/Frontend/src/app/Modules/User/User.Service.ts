import { Injectable } from '@angular/core';
import { UserEntity } from "./User.Entity";
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../HttpService';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http/src/params';
import { PasswordEntity } from './User.PasswordEntity';
import { OperationEntity } from '../Operation/Operation.Entity';

@Injectable()
export class UserService extends HttpService<UserEntity> {
  public Routes: OperationEntity[];
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = "api/Users";
    this.Routes = [];
  }
  
  Current(): UserEntity {
    var CookieData = this.getCookie("JWT");
    let Substring = CookieData.substring(CookieData.indexOf('.') + 1, CookieData.length)
    let FinalSubstring = Substring.substring(0, Substring.indexOf('.'));
    let Json = this.Base64.decode(FinalSubstring);
    Json = JSON.parse(Json);
    return Json.UserEntity;
  }
  changePassword(OldPassword: string, UserEntity: UserEntity, IsShowLoading?: boolean): Observable<boolean> {
    let body = new PasswordEntity(UserEntity, OldPassword);
    return this.intercept(this.http.put<UserEntity>(`${this.url}/${body.UserEntity.Id}/ChangePassword`, JSON.stringify(body), { observe: 'response', headers: this.GetHeaders() }), IsShowLoading).map(r => r.body);
  }
  getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) return parts.pop().split(";").shift();
  }

  Base64: any = {
    encode: function (string) {
      var characters = this.Base64.characters;
      var result = '';

      var i = 0;
      do {
        var a = string.charCodeAt(i++);
        var b = string.charCodeAt(i++);
        var c = string.charCodeAt(i++);

        a = a ? a : 0;
        b = b ? b : 0;
        c = c ? c : 0;

        var b1 = (a >> 2) & 0x3F;
        var b2 = ((a & 0x3) << 4) | ((b >> 4) & 0xF);
        var b3 = ((b & 0xF) << 2) | ((c >> 6) & 0x3);
        var b4 = c & 0x3F;

        if (!b) {
          b3 = b4 = 64;
        } else if (!c) {
          b4 = 64;
        }

        result += this.Base64.characters.charAt(b1) + this.Base64.characters.charAt(b2) + this.Base64.characters.charAt(b3) + this.Base64.characters.charAt(b4);

      } while (i < string.length);

      return result;
    },

    decode: function (string) {
      var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
      var result = '';

      var i = 0;
      do {
        var b1 = characters.indexOf(string.charAt(i++));
        var b2 = characters.indexOf(string.charAt(i++));
        var b3 = characters.indexOf(string.charAt(i++));
        var b4 = characters.indexOf(string.charAt(i++));

        var a = ((b1 & 0x3F) << 2) | ((b2 >> 4) & 0x3);
        var b = ((b2 & 0xF) << 4) | ((b3 >> 2) & 0xF);
        var c = ((b3 & 0x3) << 6) | (b4 & 0x3F);

        result += String.fromCharCode(a) + (b ? String.fromCharCode(b) : '') + (c ? String.fromCharCode(c) : '');

      } while (i < string.length);

      return result;
    }
  };
}
