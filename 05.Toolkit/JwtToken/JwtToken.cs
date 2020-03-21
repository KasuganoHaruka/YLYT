using _02.Entitys;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace _05.Toolkit.JwtToken
{

    /// <summary>
    /// JWT是由 . 分割的三部分组成：
    /// 头部(Header)
    /// 载荷(Payload) : 这一部分是JWT主要的信息存储部分，其中包含了许多种的声明（claims）。
    /// 签名(Signature)：使用保存在服务端的秘钥对其签名，用来验证发送者的JWT的同时也能确保在期间不被篡改。
    /// </summary>
    public class JwtToken
    {

        /// <summary>
        /// 获取JWT字符串并存入缓存
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="expireSliding"></param>
        /// <param name="expireAbsoulte"></param>
        /// <returns></returns>
        public static string IssueJWT(Account account, TimeSpan expiresSliding, TimeSpan expiresAbsoulte)
        {
            DateTime UTC = DateTime.UtcNow;

            /**
            * Claims (Payload)
               Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:

               iss: The issuer of the token，token 是给谁的  发送者
               aud: 接收的
               sub: The subject of the token，token 主题
               exp: Expiration Time。 token 过期时间，Unix 时间戳格式
               jti: JWT ID。针对当前 token 的唯一标识
               iat: Issued At。 token 创建时间， Unix 时间戳格式
               除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
            * */
            Claim[] claims = new Claim[]
            {
                //new Claim(ClaimTypes.Role, admin)//在这可以分配用户角色，比如管理员 、 vip会员 、 普通用户等
                new Claim(JwtRegisteredClaimNames.Sub,account.User.User_Name),//Subject,
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),//JWT ID,JWT的唯一标识
                new Claim(JwtRegisteredClaimNames.Iat, UTC.ToString(), ClaimValueTypes.Integer64),//Issued At，JWT颁发的时间，采用标准unix时间，用于验证过期
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "そら",//jwt签发者,非必须
                audience: account.User.User_Name,//token的接收该方，非必须
                claims: claims,//声明集合
                expires: UTC.AddHours(12),//指定token的生命周期，unix时间戳格式,非必须
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("そら the Secret Key")),
                                                            SecurityAlgorithms.HmacSha256));//使用私钥进行签名加密

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);//生成最后的JWT字符串

            RayPIMemoryCache.AddMemoryCache(encodedJwt, account, expiresSliding, expiresAbsoulte);//将JWT字符串和tokenModel作为key和value存入缓存
            return encodedJwt;
        }

    }

}