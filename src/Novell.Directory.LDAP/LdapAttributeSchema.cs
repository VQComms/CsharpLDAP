/******************************************************************************
* The MIT License
* Copyright (c) 2003 Novell Inc.  www.novell.com
* 
* Permission is hereby granted, free of charge, to any person obtaining  a copy
* of this software and associated documentation files (the Software), to deal
* in the Software without restriction, including  without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
* copies of the Software, and to  permit persons to whom the Software is 
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in 
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*******************************************************************************/
//
// Novell.Directory.Ldap.LdapAttributeSchema.cs
//
// Author:
//   Sunil Kumar (Sunilk@novell.com)
//
// (C) 2003 Novell, Inc (http://www.novell.com)
//

using System;
using Novell.Directory.LDAP.VQ.Utilclass;

namespace Novell.Directory.LDAP.VQ
{

    /// <summary> The definition of an attribute type in the schema.
    /// 
    /// LdapAttributeSchema is used to discover an attribute's
    /// syntax, and add or delete an attribute definition.
    /// RFC 2252, "Lightweight Directory Access Protocol (v3):
    /// Attribute Syntax Definitions" contains a description
    /// of the information on the Ldap representation of schema.
    /// draft-sermerseim-nds-ldap-schema-02, "Ldap Schema for NDS"
    /// defines the schema descriptions and non-standard syntaxes
    /// used by Novell eDirectory.
    /// 
    /// </summary>
    /// <seealso cref="LdapSchema">
    /// </seealso>
    public class LdapAttributeSchema : LdapSchemaElement
    {
        private void InitBlock()
        {
            usage = USER_APPLICATIONS;
        }
        /// <summary> Returns the object identifer of the syntax of the attribute, in
        /// dotted numerical format.
        /// 
        /// </summary>
        /// <returns> The object identifer of the attribute's syntax.
        /// </returns>
        virtual public string SyntaxString
        {
            get
            {
                return syntaxString;
            }

        }
        /// <summary> Returns the name of the attribute type which this attribute derives
        /// from, or null if there is no superior attribute.
        /// 
        /// </summary>
        /// <returns> The attribute's superior attribute, or null if there is none.
        /// </returns>
        virtual public string Superior
        {
            get
            {
                return superior;
            }

        }
        /// <summary> Returns true if the attribute is single-valued.
        /// 
        /// </summary>
        /// <returns> True if the attribute is single-valued; false if the attribute
        /// is multi-valued.
        /// </returns>
        virtual public bool SingleValued
        {
            get
            {
                return single;
            }

        }
        /// <summary> Returns the matching rule for this attribute.
        /// 
        /// </summary>
        /// <returns> The attribute's equality matching rule; null if it has no equality
        /// matching rule.
        /// </returns>
        virtual public string EqualityMatchingRule
        {
            get
            {
                return equality;
            }

        }
        /// <summary> Returns the ordering matching rule for this attribute.
        /// 
        /// </summary>
        /// <returns> The attribute's ordering matching rule; null if it has no ordering
        /// matching rule.
        /// </returns>
        virtual public string OrderingMatchingRule
        {
            get
            {
                return ordering;
            }

        }
        /// <summary> Returns the substring matching rule for this attribute.
        /// 
        /// </summary>
        /// <returns> The attribute's substring matching rule; null if it has no substring
        /// matching rule.
        /// </returns>
        virtual public string SubstringMatchingRule
        {
            get
            {
                return substring;
            }

        }
        /// <summary> Returns true if the attribute is a collective attribute.
        /// 
        /// </summary>
        /// <returns> True if the attribute is a collective; false if the attribute
        /// is not a collective attribute.
        /// </returns>
        virtual public bool Collective
        {
            get
            {
                return collective;
            }

        }
        /// <summary> Returns false if the attribute is read-only.
        /// 
        /// </summary>
        /// <returns> False if the attribute is read-only; true if the attribute
        /// is read-write.
        /// </returns>
        virtual public bool UserModifiable
        {
            get
            {
                return userMod;
            }

        }
        /// <summary> Returns the usage of the attribute.
        /// 
        /// </summary>
        /// <returns> One of the following values: USER_APPLICATIONS,
        /// DIRECTORY_OPERATION, DISTRIBUTED_OPERATION or
        /// DSA_OPERATION.
        /// </returns>
        virtual public int Usage
        {
            get
            {
                return usage;
            }

        }

        private string syntaxString;
        private bool single = false;
        private string superior;
        private string equality;
        private string ordering;
        private string substring;
        private bool collective = false;
        private bool userMod = true;
        private int usage;

        /// <summary> Indicates that the attribute usage is for ordinary application
        /// or user data.
        /// </summary>
        public const int USER_APPLICATIONS = 0;
        /// <summary> Indicates that the attribute usage is for directory operations.
        /// Values are vendor specific.
        /// </summary>
        public const int DIRECTORY_OPERATION = 1;
        /// <summary> Indicates that the attribute usage is for distributed operational
        /// attributes. These hold server (DSA) information that is shared among
        /// servers holding replicas of the entry.
        /// </summary>
        public const int DISTRIBUTED_OPERATION = 2;
        /// <summary> Indicates that the attribute usage is for local operational attributes.
        /// These hold server (DSA) information that is local to a server.
        /// </summary>
        public const int DSA_OPERATION = 3;

        /// <summary> Constructs an attribute definition for adding to or deleting from a
        /// directory's schema.
        /// 
        /// </summary>
        /// <param name="names">Names of the attribute.
        /// 
        /// </param>
        /// <param name="oid">  Object identifer of the attribute, in
        /// dotted numerical format.
        /// 
        /// </param>
        /// <param name="description">  Optional description of the attribute.
        /// 
        /// </param>
        /// <param name="syntaxString"> Object identifer of the syntax of the
        /// attribute, in dotted numerical format.
        /// 
        /// </param>
        /// <param name="single">   True if the attribute is to be single-valued.
        /// 
        /// </param>
        /// <param name="superior"> Optional name of the attribute type which this
        /// attribute type derives from; null if there is no
        /// superior attribute type.
        /// 
        /// </param>
        /// <param name="obsolete"> True if the attribute is obsolete.
        /// 
        /// </param>
        /// <param name="equality"> Optional matching rule name; null if there is not
        /// an equality matching rule for this attribute.
        /// 
        /// </param>
        /// <param name="ordering">Optional matching rule name; null if there is not
        /// an ordering matching rule for this attribute.
        /// 
        /// </param>
        /// <param name="substring">   Optional matching rule name; null if there is not
        /// a substring matching rule for this attribute.
        /// 
        /// </param>
        /// <param name="collective">   True of this attribute is a collective attribute
        /// 
        /// </param>
        /// <param name="isUserModifiable"> False if this attribute is a read-only attribute
        /// 
        /// </param>
        /// <param name="usage">       Describes what the attribute is used for. Must be
        /// one of the following: USER_APPLICATIONS,
        /// DIRECTORY_OPERATION, DISTRIBUTED_OPERATION or
        /// DSA_OPERATION.
        /// </param>
        public LdapAttributeSchema(string[] names, string oid, string description, string syntaxString, bool single, string superior, bool obsolete, string equality, string ordering, string substring, bool collective, bool isUserModifiable, int usage) : base(LdapSchema.schemaTypeNames[LdapSchema.ATTRIBUTE])
        {
            InitBlock();
            this.names = names;
            this.oid = oid;
            this.description = description;
            this.obsolete = obsolete;
            this.syntaxString = syntaxString;
            this.single = single;
            this.equality = equality;
            this.ordering = ordering;
            this.substring = substring;
            this.collective = collective;
            userMod = isUserModifiable;
            this.usage = usage;
            this.superior = superior;
            Value = formatString();
            return;
        }



        /// <summary> Constructs an attribute definition from the raw string value returned
        /// on a directory query for "attributetypes".
        /// 
        /// </summary>
        /// <param name="raw">     The raw string value returned on a directory
        /// query for "attributetypes".
        /// </param>
        public LdapAttributeSchema(string raw) : base(LdapSchema.schemaTypeNames[LdapSchema.ATTRIBUTE])
        {
            InitBlock();
            try
            {
                SchemaParser parser = new SchemaParser(raw);

                if (parser.Names != null)
                    names = parser.Names;
                if ((object)parser.ID != null)
                    oid = parser.ID;
                if ((object)parser.Description != null)
                    description = parser.Description;
                if ((object)parser.Syntax != null)
                    syntaxString = parser.Syntax;
                if ((object)parser.Superior != null)
                    superior = parser.Superior;
                single = parser.Single;
                obsolete = parser.Obsolete;
                System.Collections.IEnumerator qualifiers = parser.Qualifiers;
                AttributeQualifier attrQualifier;
                while (qualifiers.MoveNext())
                {
                    attrQualifier = (AttributeQualifier)qualifiers.Current;
                    setQualifier(attrQualifier.Name, attrQualifier.Values);
                }
                Value = formatString();
            }
            catch (System.IO.IOException e)
            {
                throw new Exception(e.ToString());
            }
        }

        /// <summary> Returns a string in a format suitable for directly adding to a
        /// directory, as a value of the particular schema element attribute.
        /// 
        /// </summary>
        /// <returns> A string representation of the attribute's definition.
        /// </returns>
        protected internal override string formatString()
        {
            System.Text.StringBuilder valueBuffer = new System.Text.StringBuilder("( ");
            string token;
            string[] strArray;

            if ((object)(token = ID) != null)
            {
                valueBuffer.Append(token);
            }
            strArray = Names;
            if (strArray != null)
            {
                valueBuffer.Append(" NAME ");
                if (strArray.Length == 1)
                {
                    valueBuffer.Append("'" + strArray[0] + "'");
                }
                else
                {
                    valueBuffer.Append("( ");

                    for (int i = 0; i < strArray.Length; i++)
                    {
                        valueBuffer.Append(" '" + strArray[i] + "'");
                    }
                    valueBuffer.Append(" )");
                }
            }
            if ((object)(token = Description) != null)
            {
                valueBuffer.Append(" DESC ");
                valueBuffer.Append("'" + token + "'");
            }
            if (Obsolete)
            {
                valueBuffer.Append(" OBSOLETE");
            }
            if ((object)(token = Superior) != null)
            {
                valueBuffer.Append(" SUP ");
                valueBuffer.Append("'" + token + "'");
            }
            if ((object)(token = EqualityMatchingRule) != null)
            {
                valueBuffer.Append(" EQUALITY ");
                valueBuffer.Append("'" + token + "'");
            }
            if ((object)(token = OrderingMatchingRule) != null)
            {
                valueBuffer.Append(" ORDERING ");
                valueBuffer.Append("'" + token + "'");
            }
            if ((object)(token = SubstringMatchingRule) != null)
            {
                valueBuffer.Append(" SUBSTR ");
                valueBuffer.Append("'" + token + "'");
            }
            if ((object)(token = SyntaxString) != null)
            {
                valueBuffer.Append(" SYNTAX ");
                valueBuffer.Append(token);
            }
            if (SingleValued)
            {
                valueBuffer.Append(" SINGLE-VALUE");
            }
            if (Collective)
            {
                valueBuffer.Append(" COLLECTIVE");
            }
            if (UserModifiable == false)
            {
                valueBuffer.Append(" NO-USER-MODIFICATION");
            }
            int useType;
            if ((useType = Usage) != USER_APPLICATIONS)
            {
                switch (useType)
                {

                    case DIRECTORY_OPERATION:
                        valueBuffer.Append(" USAGE directoryOperation");
                        break;

                    case DISTRIBUTED_OPERATION:
                        valueBuffer.Append(" USAGE distributedOperation");
                        break;

                    case DSA_OPERATION:
                        valueBuffer.Append(" USAGE dSAOperation");
                        break;

                    default:
                        break;

                }
            }
            System.Collections.IEnumerator en = QualifierNames;

            while (en.MoveNext())
            {
                token = ((string)en.Current);
                if (((object)token != null))
                {
                    valueBuffer.Append(" " + token);
                    strArray = getQualifier(token);
                    if (strArray != null)
                    {
                        if (strArray.Length > 1)
                            valueBuffer.Append("(");
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            valueBuffer.Append(" '" + strArray[i] + "'");
                        }
                        if (strArray.Length > 1)
                            valueBuffer.Append(" )");
                    }
                }
            }
            valueBuffer.Append(" )");
            return valueBuffer.ToString();
        }
    }
}
