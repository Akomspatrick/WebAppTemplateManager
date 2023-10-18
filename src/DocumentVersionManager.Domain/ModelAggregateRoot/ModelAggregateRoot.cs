using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public partial class Model : BaseEntity
    {

        //public Model(string modelId, string modelName, string modelTypeId)
        //{
        //    ModelId = modelId;
        //    ModelName = modelName;
        //    ModelTypeId = modelTypeId;
        //}

        public static Model Create(string modelId, string modelName, string modelTypeId)
        {

            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentNullException(nameof(modelName));

            }
            if (modelName.Length > FixedValues.ModelNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelNameMaxLength} characters {nameof(modelName)} ");
            }

            if (modelName.Length < FixedValues.ModelNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelNameMaxLength}  characters  {nameof(modelName)} ");
            }


            if (string.IsNullOrWhiteSpace(modelTypeId))
            {
                throw new ArgumentNullException(nameof(modelTypeId));

            }
            if (modelTypeId.Length > FixedValues.ModelTypeIdMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelTypeIdMaxLength} characters {nameof(modelTypeId)} ");
            }

            if (modelTypeId.Length < FixedValues.ModelTypeIdMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelTypeIdMinLength} characters {nameof(modelTypeId)} ");
            }


            if (string.IsNullOrWhiteSpace(modelId))
            {
                throw new ArgumentNullException(nameof(modelId));

            }
            if (modelId.Length > FixedValues.ModelIdMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelIdMaxLength} characters {nameof(modelId)} ");
            }

            if (modelId.Length < FixedValues.ModelIdMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelIdMinLength} characters {nameof(modelId)} ");
            }

            return new Model() {ModelId= modelId,   ModelTypesId = modelTypeId, ModelName = modelName };

        }


        #region Accessors

        public List<int> GetUniqueCapacities()
        {
            List<int> temp = new List<int>();

            foreach (CapacitySpecification cs in _capacitySpecifications)
            {
                temp.Add(cs.Capacity);
            }

            return temp.Distinct().ToList();
        }

        public List<CapacitySpecification> GetUniqueCapacitySpecifications()
        {
            List<CapacitySpecification> temp = new List<CapacitySpecification>();

            foreach (int capacity in GetUniqueCapacities())
            {
                temp.Add(GetLatestCapacitySpecification(capacity));
            }

            return temp;
        }

        public static string GetShortCapacityString(int capacity, MassUnits units)
        {
            switch (units)
            {
                case MassUnits.Kilograms:
                    break;
                case MassUnits.Pounds:
                    return (capacity * .001).ToString().Replace('.', 'k');
            }

            return "";
        }

        public CapacitySpecification GetLatestCapacitySpecification(int capacity)
        {
            CapacitySpecification result = null;

            foreach (CapacitySpecification cs in _capacitySpecifications)
            {
                if (cs.Capacity == capacity)
                {
                    if (result == null) { result = cs; }
                    else if (cs.Timestamp.CompareTo(result.Timestamp) > 0) { result = cs; }
                }
            }

            return result;
        }

        public DateTime? GetLatestCapacitySpecificationTimestamp(int capacity)
        {
            CapacitySpecification result = null;

            foreach (CapacitySpecification cs in _capacitySpecifications)
            {
                if (cs.Capacity == capacity)
                {
                    if (result == null) { result = cs; }
                    else if (cs.Timestamp.CompareTo(result.Timestamp) > 0) { result = cs; }
                }
            }

            if (result != null)
            {
                return result.Timestamp;
            }
            else
            {
                return null;
            }
        }

        public CapacitySpecification GetCapacitySpecificationByTimestamp(int capacity, DateTime timestamp)
        {
            CapacitySpecification result = null;

            foreach (CapacitySpecification cs in _capacitySpecifications)
            {
                if (cs.Capacity == capacity)
                {
                    if (result == null) { result = cs; }
                    else if ((timestamp.CompareTo(cs.Timestamp) >= 0) && ((cs.Timestamp.CompareTo(result.Timestamp) > 0) ||
                        ((result.Timestamp.CompareTo(timestamp) > 0) && (cs.Timestamp.CompareTo(timestamp) >= 0)))) { result = cs; }
                }
            }

            return result;
        }

        public void UpdateCapacitySpecification(CapacitySpecification cs, string authUser)
        {
            CapacitySpecification result = null;
            int index = 0;

            for (int i = 0; i < _capacitySpecifications.Count; i++)
            {
                if (_capacitySpecifications[i].Capacity == cs.Capacity)
                {
                    if (result == null)
                    {
                        result = _capacitySpecifications[i];
                        index = i;
                    }
                    else if (_capacitySpecifications[i].Timestamp.CompareTo(result.Timestamp) > 0)
                    {
                        result = _capacitySpecifications[i];
                        index = i;
                    }
                }
            }

            _capacitySpecifications[index] = CapacitySpecification.Duplicate(cs, authUser);

        }

        #endregion Accessors
        #region Copy

        #endregion Copy

        #region Polling == tHIS SHOULD BE DONE IN THE INFRASTRUCTURE LAYER

        //private static void pollWaitCallback(object stateInfo)
        //{
        //    while (polling)
        //    {
        //        if (DataUpdated != null)
        //        {
        //            Dictionary<string, List<int>> models = new Dictionary<string, List<int>>();

        //            foreach (string name in Model.GetNames())
        //            {
        //                models.Add(name, new List<int>());
        //                Model model = Model.Query(name);

        //                models[name] = model.GetUniqueCapacities();
        //            }

        //            DataUpdated(models);
        //        }

        //        Thread.Sleep(1000);
        //    }
        //}

        //public static void StartPoll()
        //{
        //    lock (pollingLock)
        //    {
        //        if (!polling)
        //        {
        //            polling = true;
        //            ThreadPool.QueueUserWorkItem(new WaitCallback(pollWaitCallback));
        //        }
        //    }
        //}

        //public static void StopPoll()
        //{
        //    lock (pollingLock)
        //    {
        //        if (polling)
        //        {
        //            polling = false;
        //        }
        //    }
        //}

        #endregion Polling
    }
}
