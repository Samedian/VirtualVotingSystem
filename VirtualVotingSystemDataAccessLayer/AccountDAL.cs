using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;
using VirtualVotingSystemExceptions;

namespace VirtualVotingSystemDataAccessLayer
{
    public class AccountDAL : IAccountDAL
    {
        private readonly IModelToEntityManager _modelToEntityManager;
        
        
        public AccountDAL(IModelToEntityManager modelToEntityManager)
        {
            _modelToEntityManager = modelToEntityManager;
        }

        public async  Task<string> Login(string UserName, string Password)
        {
            using(var context= new VirtualVotingSystemContext() )
            {
                string res = null;
                try
                {
                    var result = context.AdminCredentials.FirstOrDefault(u => u.LoginId == UserName
                         && u.Pass == Password);

                    if (result != null)
                    {
                        res = "Admin";
                        return res;
                    }
                        


                    var data = context.UserIds.FirstOrDefault(u => u.Vvid == UserName
                         && u.Pass == Password);
                    if (data != null)
                        res = ("User");
                    else
                        res = null;
                    return await Task.FromResult(res);
                }catch(SqlException ex)
                {
                    throw ex.InnerException;
                }catch(Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public async Task<UserDetailEntity> GetUserDetailsByAadhar(string AadharNumber)
        {

            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var  addressDetail =
                   (from address in context.AddressDetails
                      join user in context.UserDetails on address.AddressId equals user.AddressId
                      where Convert.ToString(user.AadharNumber).Equals(AadharNumber)
                      select address).FirstOrDefault();

                    if(addressDetail==null)
                    {
                        throw new DataNotFound("Data Not Found for this record");
                    }
                   
                    var userDetail = context.UserDetails.FirstOrDefault(user => 
                        Convert.ToString(user.AadharNumber).Equals(AadharNumber));

                    UserDetailEntity userDetailEntity =  _modelToEntityManager.GetUserDetailEntity(userDetail, addressDetail);
                    return await Task.FromResult(userDetailEntity);

                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }

        }

        public async Task<string> SaveId(UserIdEntity userIdEntity)
        {
            UserId userId = _modelToEntityManager.GetUserId(userIdEntity);
            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var data = context.UserIds.FirstOrDefault(x => x.AadharNumber == userId.AadharNumber);

                    if (data != null)
                        throw new DataPresentException("You have Registred");
                    context.UserIds.Add(userId);
                    context.SaveChanges();

                    return await Task.FromResult("Success");

                }catch(DataPresentException)
                {
                    return "Registred";
                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;

                }
            }
        }
    }
}
